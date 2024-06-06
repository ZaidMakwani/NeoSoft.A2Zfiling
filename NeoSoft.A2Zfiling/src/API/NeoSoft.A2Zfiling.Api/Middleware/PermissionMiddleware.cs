using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Persistence;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Security.Claims;

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


            //{
            //    var token = await _tokenService.GetTokenAsync();

            //    Console.WriteLine($"Token from database: {token}");

            //    // Continue the middleware pipeline
            //    await _next(context);



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





            //    var user = context.User;

            //    if (!user.Identity.IsAuthenticated)
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        return;
            //    }

            //    var controllerName = context.Request.RouteValues["controller"]?.ToString();
            //    var actionName = context.Request.RouteValues["action"]?.ToString();

            //    if (!CheckUserPermission(user, controllerName, actionName))
            //    {
            //        context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //        return;
            //    }

            //    await _next(context);
            //}

            //private bool CheckUserPermission(ClaimsPrincipal user, string controllerName, string actionName)
            //{
            //    var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            //    var userRoles = _dbContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToList();

            //    var permission = _dbContext.Permission.FirstOrDefault(p => p.ControllerName == controllerName && p.ActionName == actionName);
            //    if (permission == null)
            //    {
            //        return false;
            //    }

            //    var rolePermissions = _dbContext.User
            //        .Where(rp => userRoles.Contains(rp.RoleId.ToString()) && rp.PermissionId == permission.PermissionId)
            //        .ToList();

            //    return rolePermissions.Any();
            //}
        }
    }
}



