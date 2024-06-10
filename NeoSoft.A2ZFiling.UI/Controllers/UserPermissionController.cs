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
                if (rolesId == null)
                {
                    return NotFound("Role not found");
                }

                var allUserPermission = await _userPermission.GetUserPermissionAsync();
                var userPermission = allUserPermission.Where(x => x.RoleId == roleId).ToList();
                var allPermission = await _permissionService.GetPermissionAsync();
                var role = await _roleService.GetRoleByIdAsync(roleId);

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

                // Retrieve existing permissions for the role
                var allPermissions = await _userPermission.GetUserPermissionAsync();

                foreach (var permission in model.SelectedPermissions)
                {
                    // Check if the permission already exists
                    var existingPermission = allPermissions.FirstOrDefault(x => x.RoleId == model.RoleId && x.PermissionId == permission);

                    if (existingPermission != null)
                    {
                        // Update existing permission
                        existingPermission.IsActive = true;
                        var response = await _userPermission.UpdateUserPermissionAsync(existingPermission);
                        if (response == null)
                        {
                            _logger.LogError("Failed to update user permission");
                            return BadRequest("Failed to update user permission");
                        }
                    }
                    else
                    {
                        // Create new permission
                        var newPermission = new UserPermissionVM
                        {
                            RoleId = model.RoleId,
                            PermissionId = permission,
                            IsActive = true
                        };
                        var response = await _userPermission.CreateUserPermissionAsync(newPermission);
                        if (response == null)
                        {
                            _logger.LogError("Failed to create user permission");
                            return BadRequest("Failed to create user permission");
                        }
                    }
                }

                // Check for unchecked permissions
                foreach (var permission in allPermissions)
                {
                    if (!model.SelectedPermissions.Contains(permission.PermissionId))
                    {
                        // Permission is unchecked, update its status to inactive
                        permission.IsActive = false;
                        var response = await _userPermission.UpdateUserPermissionAsync(permission);
                        if (response == null)
                        {
                            _logger.LogError("Failed to update user permission");
                            return BadRequest("Failed to update user permission");
                        }
                    }
                }

                _logger.LogInformation("Update User Permission Action Completed");
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


