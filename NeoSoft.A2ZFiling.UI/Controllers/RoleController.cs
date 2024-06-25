using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    
    public class RoleController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _httpClient;
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _roleService = roleService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return PartialView("_PartialLayoutCreate");
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM role)
        {
            _logger.LogInformation("Create Role action is initiated");
            var isExist = _roleService.GetRolesAsync().Result.Where(x => x.RoleName == role.RoleName);

            if (isExist.Any())
            {
                return BadRequest("Role Already Exists!!!");
            }
            else
            {
                var response = await _roleService.CreateRoleAsync(role);

                if (response != null)
                {
                    return RedirectToAction("GetAllRoles");
                }
                else
                {

                    return View(response);
                }
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _roleService.GetRoleByIdAsync(id);

                return PartialView("_PartialLayoutEdit", result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleVM role)
        {
            var IsExist = await _roleService.GetRoleByIdAsync(role.RoleId);
            if (IsExist.IsActive)
            {
                role.IsActive = true;
                var result = await _roleService.UpdateRoleAsync(role);
                return Ok(result);
            }
            else
            {
                return BadRequest("Role is Inactive!!");
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {

            var response = await _roleService.GetRolesAsync();

            return Ok(response);

        }
        public async Task<IActionResult> GetAllRole()
        {

            var response = await _roleService.GetAllRolesAsync();

            return View(response);

        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _roleService.DeleteRoleAsync(id);
            return Ok();
        }

    }
}
