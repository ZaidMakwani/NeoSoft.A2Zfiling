using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class UserPermissionController : Controller
    {
        private readonly ILogger<UserPermissionController> _logger;
        private readonly IUserPermission _userPermission;

        public UserPermissionController(ILogger<UserPermissionController> logger, IUserPermission userPermission)
        {
            _logger = logger;
          _userPermission = userPermission;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll User Permission Action Initiated");

                var response = await _userPermission.GetUserPermissionAsync();
                _logger.LogInformation("GetAll User Permission Action Completed");
                return View(response);
            }

            catch (Exception ex)
            {
                _logger.LogError("An error occurred whike getting all permission");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
