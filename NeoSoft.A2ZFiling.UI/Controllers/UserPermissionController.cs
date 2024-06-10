using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;
using System.Data;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class UserPermissionController : Controller
    {
        private readonly ILogger<UserPermissionController> _logger;
        private readonly IUserPermission _userPermission;
        private readonly IPermissionService _permissionService;
        private readonly IRoleService _roleService;

        public UserPermissionController(ILogger<UserPermissionController> logger, IUserPermission userPermission, IPermissionService permissionService, IRoleService roleService)
        {
            _logger = logger;
            _userPermission = userPermission;
            _permissionService = permissionService;
            _roleService = roleService;
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



        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                var permissions = await _permissionService.GetPermissionAsync();

                var role = await _roleService.GetRolesAsync();
                var mappedPermissions = permissions
                    .GroupBy(p => p.ControllerName)
                    .Select(group => new UserPermissionVM
                    {
                        ControllerName = group.Key,
                        Actions = group.Select(p => new PermissionVM
                        {
                            PermissionId = p.PermissionId,
                            ActionName = p.ActionName,
                            ControllerName = p.ControllerName,
                            IsActive = p.IsActive,
                        }).ToList(),
                        RoleId = role.FirstOrDefault().RoleId,
                        RoleName = role.FirstOrDefault()?.RoleName
                    }).ToList();
                return View(mappedPermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving permissions for create page: {ex.Message}");
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserPermissionVM model)
        {
            try
            {
                _logger.LogInformation("Create  User Permission Action Initiated");
                if (model.RoleId==null || model.RoleId==0)
                {
                    _logger.LogError("No Role selected");
                    return BadRequest("No Role selected");
                }
                if (model.SelectedPermissions == null || !model.SelectedPermissions.Any())
                {
                    _logger.LogError("No permissions selected");
                    return BadRequest("No permissions selected");
                }

                foreach (var permissionId in model.SelectedPermissions)
                {
                    var userPermission = new UserPermissionVM
                    {
                        RoleId = model.RoleId,
                        IsActive = true,
                        PermissionId = permissionId,
                    };
                    var response = await _userPermission.CreateUserPermissionAsync(userPermission);
                    if (response == null)
                    {
                        _logger.LogError("Failed to create user permission");
                        return BadRequest("Failed to create user permission");
                    }
                }

                _logger.LogInformation("Create User Permission Action Completed");
                return RedirectToAction("GetAll", "UserPermission");


            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while creating user permission");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete User Permission Action Initiated");
                var response = await _userPermission.DeleteUserPermissionAsync(id);
                _logger.LogInformation("Delete User Permission Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating user permission.");
                return StatusCode(500, "An error occurred while creating user permission.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int roleId)
        {
            try
            {
                _logger.LogInformation("Edit User Permission Action Initiated");


                var rolesId = await _roleService.GetRoleByIdAsync(roleId);

                // Check if role is null
                if (rolesId == null)
                {
                    return NotFound("Role not found");
                }

                var allUserPermission = await _userPermission.GetUserPermissionAsync();
                var userPermission = allUserPermission.Where(x => x.RoleId == roleId).ToList();

                // Fetch all permissions
                var allPermission = await _permissionService.GetPermissionAsync();

                // Fetch role information
                var role = await _roleService.GetRoleByIdAsync(roleId);

                // Map permissions to view model
                var mappedPermissions = allPermission
                        .GroupBy(p => p.ControllerName)
                        .Select(group => new UserPermissionVM
                        {
                            ControllerName = group.Key,
                            Actions = group.Select(p => new PermissionVM
                            {
                                PermissionId = p.PermissionId,
                                ActionName = p.ActionName,
                                ControllerName = p.ControllerName,
                                IsActive = userPermission.Any(x => x.PermissionId == p.PermissionId),
                            }).ToList(),
                            RoleId = role.RoleId, 
                            RoleName = role?.RoleName
                        }).ToList();

                _logger.LogInformation("Edit User Permission Action Completed");
                return View(mappedPermissions);
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing user permission.");
                return StatusCode(500, "An error occurred while editing user permission.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserPermissionVM model)
        {
            try
            {
                _logger.LogInformation("Edit User Permission Action Initiated");
                if (model == null)
                {
                    _logger.LogError("Edit User Permission: Model is null");
                    return BadRequest("Model is null");
                }
                if (model.RoleId == null || model.RoleId == 0)
                {
                    _logger.LogError("No Role selected");
                    return BadRequest("No Role selected");
                }
                if (model.SelectedPermissions == null || !model.SelectedPermissions.Any())
                {
                    _logger.LogError("No permissions selected");
                    return BadRequest("No permissions selected");
                }
                _logger.LogInformation($"Role ID: {model.RoleId}");
                foreach (var permission in model.Actions)
                {
                    _logger.LogInformation($"Permission ID: {permission.PermissionId}, IsActive: {permission.IsActive}");
                }

                foreach (var permission in model.Actions)
                {
                    var userPermission = new UserPermissionVM
                    {
                        RoleId = model.RoleId,
                        PermissionId = permission.PermissionId,
                        IsActive = permission.IsActive
                    };

                    var response = await _userPermission.UpdateUserPermissionAsync(userPermission);
                    if (response == null)
                    {
                        _logger.LogError("Failed to update user permission");
                        return BadRequest("Failed to update user permission");
                    }
                }

                _logger.LogInformation("Edit User Permission Action Completed");
                return RedirectToAction("GetAll", "UserPermission");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing user permission.");
                return StatusCode(500, "An error occurred while editing user permission.");
            }
        }


    }
}


