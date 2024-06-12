using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
//using NeosoftA2Zfilings.Views.Controllers;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class MunicipalController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MunicipalController> _logger;
        private readonly IMunicipalService _municipalService;
        private readonly IStateService _stateService;
        private readonly IZoneService _zoneService;
        private readonly ICityService _cityService;


        public MunicipalController(ILogger<MunicipalController> logger, IMunicipalService municipalService, IStateService stateService, IZoneService zoneService, ICityService cityService)
        {
            _httpClient = new HttpClient();
            _logger = logger;
            _municipalService = municipalService;
            _stateService = stateService;
            _zoneService = zoneService;
            _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var states = await _stateService.GetStateAsync();
            ViewBag.lstState = new SelectList(states, "StateId", "StateName");
            var zones = await _zoneService.GetZoneAsync();
            ViewBag.lstZone = new SelectList(zones, "ZoneId", "ZoneName");



            var cities = await _cityService.GetCityAsync();
            ViewBag.lstCity = new SelectList(cities, "CityId", "CityName");

            return PartialView("_PartialLayoutMunicipalCreate", new MunicipalVM());
        }
        [HttpPost]
        public async Task<IActionResult> Create(MunicipalVM municipal)
        {
            _logger.LogInformation("Create Role action is initiated");
            var response = await _municipalService.CreateMunicipalAsync(municipal);
            if (response != null)
            {
                return RedirectToAction("GetAllMunicipal");
            }
            else
            {
                return View(response);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMunicipal()
        {
            var response = await _municipalService.GetMunicipalAsync();

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _municipalService.GetMunicipalByIdAsync(id);

                return PartialView("_PartialLayoutMunicipalEdit", result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MunicipalVM municipal)
        {

            municipal.IsActive = true;
            var result = await _municipalService.UpdateMunicipalAsync(municipal);
            return Ok(result);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _municipalService.DeleteMunicipalAsync(id);
            return Ok();
        }

    }
}
