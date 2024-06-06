using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Persistence;
using System.Security.Claims;

namespace NeoSoft.A2Zfiling.Api.Utility
{
    public class CustomPermissionFilter : IAuthorizationFilter
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomPermissionFilter(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var controllerName = context.RouteData.Values["controller"]?.ToString();
            var actionName = context.RouteData.Values["action"]?.ToString();

            var hasPermission = CheckUserPermission(user, controllerName, actionName);
            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }

        private bool CheckUserPermission(ClaimsPrincipal user, string controllerName, string actionName)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRoles = _dbContext.UserRoles.Where(ur => ur.UserId == userId).Select(ur => ur.RoleId).ToList();

            // Retrieve the required permission based on the controller and action names
            var permission = _dbContext.Permission.FirstOrDefault(p => p.ControllerName == controllerName && p.ActionName == actionName);
            if (permission == null)
            {
                // No permission found for the controller and action
                return false;
            }

            // Check if the user's roles have access to the retrieved permission
            var rolePermissions = _dbContext.User
     .Where(rp => userRoles.Contains(rp.RoleId.ToString()) && rp.PermissionId == permission.PermissionId)
     .ToList();





            return rolePermissions.Any();
        }
    }

}
