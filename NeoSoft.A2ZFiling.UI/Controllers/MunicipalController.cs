using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
//using NeosoftA2Zfilings.Views.Controllers;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
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

            return PartialView("_PartialCreateOriginal");
        }
        [HttpPost]
        public async Task<IActionResult> Create(MunicipalVM municipal)
        {
            _logger.LogInformation("Create Role action is initiated");
            if (string.IsNullOrEmpty(municipal.MunicipalName))
            {
                return BadRequest("Please enter a valid municipal name.");
            }
            else if (string.IsNullOrEmpty(municipal.Pincode))
            {
                return BadRequest("Please enter a valid pincode name.");
            }
            else if (string.IsNullOrEmpty(municipal.CityName))
            {
                return BadRequest("Please enter a valid city name.");
            }
            else if (string.IsNullOrEmpty(municipal.ZoneName))
            {
                return BadRequest("Please enter a valid zone name.");
            }
            else if (string.IsNullOrEmpty(municipal.StateName))
            {
                return BadRequest("Please enter a valid state name.");
            }
            var response = await _municipalService.CreateMunicipalAsync(municipal);

          
            if (response != null)
            {
                return Ok(response);
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
            var municipal = await _municipalService.GetMunicipalByIdAsync(id);
            if (municipal == null) return NotFound();

            var model = new MunicipalVM
            {
                MunicipalId = municipal.MunicipalId,
               MunicipalName = municipal.MunicipalName,
                CityId = municipal.CityId,
                Pincode=municipal.Pincode,
                StateId = municipal.StateId,
                ZoneId = municipal.ZoneId,
                IsActive = municipal.IsActive,
            };

            ViewBag.lstCity = new SelectList(await _cityService.GetCityAsync(), "CityId", "CityName");
            ViewBag.lstState = new SelectList(await _stateService.GetStateAsync(), "StateId", "StateName");

            ViewBag.lstZone = new SelectList(await _zoneService.GetZoneAsync(), "ZoneId", "ZoneName");
            return PartialView("_PartialLayoutMunicipalEdit", model);
        }

        // POST: City/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(MunicipalVM model)
        {

            var municipal = await _municipalService.GetMunicipalByIdAsync(model.MunicipalId);
            if (municipal == null) return NotFound();

            municipal.MunicipalName = model.MunicipalName;
            municipal.CityId = model.CityId;
            municipal.Pincode = model.Pincode;
            municipal.ZoneId = model.ZoneId;
            municipal.StateId = model.StateId;
            municipal.IsActive = model.IsActive;

            await _municipalService.UpdateMunicipalAsync(municipal);
            return Ok(municipal);


            //ViewBag.lstState = new SelectList(await _stateService.GetStateAsync(), "StateId", "StateName");
            //ViewBag.lstZone = new SelectList(await _zoneService.GetZoneAsync(), "ZoneId", "ZoneName");
            //return PartialView("CityForm", model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _municipalService.DeleteMunicipalAsync(id);
            return Ok();
        }

    }
}
