using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeosoftA2Zfilings.Views.ViewModels;
using Newtonsoft.Json;
using System.Security.Policy;

namespace NeosoftA2Zfilings.Views.Controllers
{
    public class RoleController : Controller
    {
        
        Uri baseAddress =new Uri("https://localhost:5000/api");
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
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM role) 
        {
            _logger.LogInformation("Create Role action is initiated");
            var response= await _roleService.CreateRoleAsync(role);
            if (response != null)
            {
                return RedirectToAction("GetAllRoles");
            }
            else
            {

                return View(response);
            }
        }

        public IActionResult Edit()
        {
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles() {

            //Response<List<RoleVM>> zoneVMs = new Response<List<RoleVM>>();            //HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/v1/Roles/GetAllRoles/all").Result;            //if (response.IsSuccessStatusCode)            //{            //    string data = response.Content.ReadAsStringAsync().Result;            //    zoneVMs = JsonConvert.DeserializeObject<Response<List<RoleVM>>>(data);


            //}            //return View(zoneVMs.Data);

            var response= await _roleService.GetRolesAsync();
            
            return View(response);

        }

        
    }
}
