using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Security;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class PermissionController : Controller
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionService _permission;

        public PermissionController(ILogger<PermissionController> logger, IPermissionService permission)
        {
            _logger = logger;
            _permission = permission;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllPermission()
        {
            try
            {
                _logger.LogInformation("GetAll Permission Action Initiated");

               var response = await _permission.GetPermissionAsync(); 
                _logger.LogInformation("GetAll Permission Action Completed");
                return View(response);
            }

            catch(Exception ex)
            {
                _logger.LogError("An error occurred whike getting all permission");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_CreatePermission");
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermissionVM model)
        {
            try
            {
                _logger.LogInformation("Create Permission Action Initiated");

                if (string.IsNullOrEmpty(model.ControllerName))
                {
                    return BadRequest("Please enter a valid controller name");
                }
                if (string.IsNullOrEmpty(model.ActionName))
                {
                    return BadRequest("Please enter a valid action name");
                }
                if ((model.ControllerName.Any(char.IsDigit)) || (model.ActionName.Any(char.IsDigit)) )
                {
                    return BadRequest("Name cannot contain number");
                }


                //getting token and sending user information inside permissionVM

                //var token = HttpContext.Session.GetString("Token");

                //if (string.IsNullOrEmpty(token))
                //{
                //    return BadRequest();
                //}


                // Token found in session
                // Perform other operations with the token as needed

                //ClaimsPrincipal claimsPrincipal = JwtDecoder.DecodeJwtToken(token);

                //foreach (var claim in claimsPrincipal.Claims)
                //{
                //    Console.WriteLine($"{claim.Type}: {claim.Value}");
                //}


                //var userClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "userId");
                //var userId = userClaim.Value;


                var existingAction = (await _permission.GetPermissionAsync()).Where(x=> x.ControllerName.ToLower() == model.ControllerName.ToLower() && x.ActionName.ToLower() == model.ActionName.ToLower()).FirstOrDefault();
                if (existingAction != null)
                {
                    return BadRequest(" Permission name already exist");
                }
               

                var response = await _permission.CreatePermissionAsync(model/*, token*/);
                if (response == null)
                {
                    _logger.LogError("Failed to create permission");
                    return BadRequest("Failed to create permission");
                }
                else
                {
                    _logger.LogInformation("Create Permission Action Completed");
                    return Ok(response);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while creating permission");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete Permission Action Initiated");
                var response = await _permission.DeletePermissionAsync(id);
                _logger.LogInformation("Delete Permission Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating permission.");
                return StatusCode(500, "An error occurred while creating permission.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                _logger.LogInformation(" EditPermission Initiated");

                var getById = await _permission.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation(" EditPermission Completed");
                    return PartialView("_EditPermission", getById);
                }
                else
                {
                    _logger.LogError("The Permission is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving permission details.");
                return StatusCode(500, "An error occurred while retrieving permission details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PermissionVM model)
        {
            try
            {
                _logger.LogInformation("Edit Permission Action Initiated");

                if (string.IsNullOrEmpty(model.ControllerName))
                {
                    return BadRequest("Please enter a valid controller name");
                }
                if (string.IsNullOrEmpty(model.ActionName))
                {
                    return BadRequest("Please enter a valid action name");
                }
                if ((model.ControllerName.Any(char.IsDigit)) || (model.ActionName.Any(char.IsDigit)))
                {
                    return BadRequest("Name cannot contain number");
                }
                var existingAction = (await _permission.GetPermissionAsync()).Where(x => x.ActionName.ToLower() == model.ActionName.ToLower() && x.ControllerName.ToLower() == model.ControllerName.ToLower()).FirstOrDefault();
                if (existingAction != null)
                {
                    return BadRequest(" Permission name already exist");
                }
                var response = await _permission.UpdatePermissionAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit permission: Response was null.");
                    return BadRequest("Failed to edit permission.");
                }
                else
                {
                    _logger.LogInformation("Edit Permission Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing permission.");
                return StatusCode(500, "An error occurred while editing permission.");
            }
        }
    }
}
