using Microsoft.AspNetCore.Authorization;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Persistence;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security;

namespace NeoSoft.A2Zfiling.Api.Middleware
{
    public class PermissionMiddleware
    {
        private readonly RequestDelegate _next;

        public PermissionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //var permissionClaims = context.User.Claims.Where(x => x.Type == "permission").ToList();
            //List<string> permissions = new List<string>();
            //foreach (var claim in permissionClaims)
            //{
            //    permissions.Add(claim.Value);
            //}
            //var roleClaims = context.User.Claims.Where(x => x.Type == "realm_access").ToList();
            //string requiredPermission = "";
            //switch (context.Request.Method)
            //{
            //    case "GET":
            //        requiredPermission = "view";
            //        break;
            //    case "POST":
            //        requiredPermission = "create";
            //        break;
            //    case "PUT":
            //        requiredPermission = "edit";
            //        break;
            //    case "DELETE":
            //        requiredPermission = "delete";
            //        break;
            //    default:
            //        break;
            //}

            //if (permissions.Contains(requiredPermission) || requiredPermission == "")
            //{
            //    await _next(context);
            //}
            //else
            //{
            //    context.Response.StatusCode = 403;
            //    context.Response.ContentType = "application/json";
            //    var result = JsonConvert.SerializeObject("403 Not authorized");
            //    await context.Response.WriteAsync(result);
            //}






            var dbContext = context.RequestServices.GetService<ApplicationDbContext>();

            if (dbContext == null)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Database context not available");
                return;
            }

            var endpoint = context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<AllowAnonymousAttribute>() != null)
            {
                await _next(context);
                return;
            }

            var authorizationHeader = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid or missing Authorization header");
                return;
            }

            var token = authorizationHeader.Substring("Bearer ".Length);
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var roleIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "5")?.Value;

                if (roleIdClaim == null || !int.TryParse(roleIdClaim, out var roleId))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid RoleId claim in token");
                    return;
                }

                var routeData = context.GetRouteData();
                var currentController = routeData.Values["controller"]?.ToString();
                var currentAction = routeData.Values["action"]?.ToString();

                if (string.IsNullOrEmpty(currentController) || string.IsNullOrEmpty(currentAction))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Controller or action name missing in route data");
                    return;
                }

                var hasPermission = dbContext.User
                    .Join(dbContext.Permission,
                        up => up.PermissionId,
                        p => p.PermissionId,
                        (up, p) => new { UserPermission = up, Permission = p })
                    .Any(joined => joined.UserPermission.RoleId == roleId &&
                                   joined.Permission.ControllerName.Equals(currentController, StringComparison.OrdinalIgnoreCase) &&
                                   joined.Permission.ActionName.Equals(currentAction, StringComparison.OrdinalIgnoreCase) &&
                                   joined.UserPermission.IsActive &&
                                   joined.Permission.IsActive);

                if (!hasPermission)
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden");
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync($"Error parsing or validating JWT token: {ex.Message}");
                return;
            }

        }
    }
}
