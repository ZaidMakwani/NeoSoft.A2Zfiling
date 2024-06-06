using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System;
using NeoSoft.A2Zfiling.Persistence;
using Microsoft.EntityFrameworkCore;
using NeoSoft.A2Zfiling.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using System.Security.Claims;
using NeosoftA2Zfilings.Views.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Filter
{

    public class CustomAuthorizeAttribute : Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var httpContext = context.HttpContext;


            var token = httpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await httpContext.Response.WriteAsync("Unauthorized: Missing Authorization Header");
                //context.Result = new UnauthorizedObjectResult("Unauthorized: Missing Token in Session");
                return;
            }
            JwtSecurityToken jwtToken;
            try
            {
                jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Unauthorized: Invalid JWT token");
                context.Result = new UnauthorizedObjectResult("Unauthorized: Invalid Token");
                return;
            }
            if (jwtToken == null)
            {
                // _logger.LogWarning("Unauthorized: Invalid JWT token");
                context.Result = new UnauthorizedResult();
                return;
            }

            //var _dbContext = httpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

            ClaimsPrincipal claimsPrincipal = JwtDecoder.DecodeJwtToken(token);

            // Accessing claims
            foreach (var claim in claimsPrincipal.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }

            var permissionsClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "permissions");




            // Access the value of the permissions claim
            string permissionsJson = permissionsClaim.Value;

            // Deserialize the JSON string back to a list
            var permissionsList = JsonConvert.DeserializeObject<List<Permission>>(permissionsJson);

            // Now you have access to the permissionsList



            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();


            foreach (var permission in permissionsList)
            {
                // Split the permission string into controller and action parts




                // Check if the permission controller and action match the desired controller and action
                if (permission.ControllerName == controller && permission.ActionName == action)
                {
                    // The controller and action match, do something
                    // For example:
                    // return true;
                    await next();
                }


            }

            context.Result = new UnauthorizedObjectResult("Unauthorized: Invalid Token");
            return;

            //var roleId = roleIdClaim.Value;

            //var permissionRepository = context.HttpContext.RequestServices.GetService(typeof(IAsyncRepository<Permission>)) as IAsyncRepository<Permission>;
            //var userPermissionRepository = context.HttpContext.RequestServices.GetService(typeof(IAsyncRepository<UserPermission>)) as IAsyncRepository<UserPermission>;

            //var permissions = (await userPermissionRepository.ListAllAsync())
            //   .Where(up => up.RoleId.ToString() == roleId.ToString())
            //   .Select(up => up.PermissionId);




            //var controller = context.RouteData.Values["controller"]?.ToString();
            //var action = context.RouteData.Values["action"]?.ToString();

            //var hasPermission = (await permissionRepository.ListAllAsync())
            //  .Where(pm => permissions.Contains(pm.PermissionId) &&
            //                  pm.ControllerName == controller &&
            //                  pm.ActionName == action);

            //if (string.IsNullOrEmpty(controller) || string.IsNullOrEmpty(action))
            //{
            //    //_logger.LogWarning("Unauthorized: Missing controller or action in route data");
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}

            //var hasPermission = await _dbContext.Permission
            //  .AnyAsync(pm => permissions.Contains(pm.PermissionId) &&
            //                  pm.ControllerName == controller &&
            //                  pm.ActionName == action);

            //if (hasPermission==null)
            //{
            //    context.Result = new ForbidResult();
            //    return;
            //}


        }
    }

    public class JwtDecoder
    {
        public static ClaimsPrincipal DecodeJwtToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
        }
    }
}
