using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
namespace NeoSoft.A2ZFiling.UI.Controllers
{
    //[CustomAuthorize]
    [CustomAuthorize]
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;
        private readonly IAsyncRepository<Permission> _permissionRepository;
        private readonly IAsyncRepository<UserPermission> _userPermissionRepository;
        private readonly IStateService _stateService;
        private readonly IZoneService _zoneService;




        public CityController(ILogger<CityController> logger, ICityService cityService, IStateService stateService, IZoneService zoneService)
        {
            _logger = logger;
            _cityService = cityService;
            _stateService = stateService;
            _zoneService = zoneService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                _logger.LogInformation("City Action Initiated");
                var response = await _cityService.GetCityAsync();
                _logger.LogInformation("City Action Completed");





                return PartialView("LatestCityAll",response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try {
                var states = await _stateService.GetStateAsync();
                ViewBag.lstState = new SelectList(states, "StateId", "StateName");
                var zones = await _zoneService.GetZoneAsync();
                ViewBag.lstZone = new SelectList(zones, "ZoneId", "ZoneName");



                return PartialView("_CreateCity", new CityVM());
            }
            catch(Exception ex)
            {
                throw ex;
            }
            }

        [HttpPost]
        public async Task<IActionResult> Create(CityVM model)
        {
            try
            {
                _logger.LogInformation("Create City Action Initiated");

                if (string.IsNullOrEmpty(model.CityName))
                {
                    return BadRequest("Please enter a valid city name.");
                }
                if (model.CityName.Any(char.IsDigit))
                {
                    return BadRequest("City Name cannot contain numbers.");
                }
                if (model.CityName.Length < 3 || model.CityName.Length > 50)
                {
                    return BadRequest("City Name must be between 5 and 50 characters.");
                }

                if (string.IsNullOrEmpty(model.StateId.ToString()) || model.StateId == 0)
                {
                    return BadRequest("Please enter a valid State name.");
                }
                if (string.IsNullOrEmpty(model.ZoneId.ToString()) || model.ZoneId == 0)
                {
                    return BadRequest("Please enter a valid Zone name.");
                }
                var existingCity = (await _cityService.GetCityAsync()).Where(x => x.CityName.ToLower() == model.CityName.ToLower()).FirstOrDefault();
                if (existingCity != null)
                {
                    return BadRequest("City with this name already exists.");
                }
                var response = await _cityService.CreateCityAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create city: Response was null.");
                    return BadRequest("Failed to create city.");
                }
                else
                {
                    _logger.LogInformation("Create Zone Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCity(int id)
        {
            try
            {
                _logger.LogInformation("Delete City Action Initiated");
                var response = await _cityService.DeleteCityAsync(id);
                _logger.LogInformation("Delete City Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }



        [HttpGet]
        public async Task<IActionResult> EditCity(int id)
        {
            var city = await _cityService.GetByIdAsync(id);
             if (city == null) return NotFound();

            var model = new CityVM
            {
                CityId = city.CityId,
                CityName = city.CityName,
                StateId = city.StateId,
                ZoneId = city.ZoneId,
                IsActive = city.IsActive,
            };

            ViewBag.lstState = new SelectList(await _stateService.GetStateAsync(), "StateId", "StateName");
            ViewBag.lstZone = new SelectList(await _zoneService.GetZoneAsync(), "ZoneId", "ZoneName");
            return PartialView("_EditCity", model);
        }

        // POST: City/Edit
        [HttpPost]
        public async Task<IActionResult> EditCity(CityVM model)
        {
       
            var city = await _cityService.GetByIdAsync(model.CityId);
            if (string.IsNullOrEmpty(model.CityName))
            {
                return BadRequest("Please enter a valid city name.");
            }
            if (model == null) return NotFound();

           
            if (model.ZoneId == 0 || model.StateId == 0 || model.ZoneId == null || model.StateId == null)
            {
                return BadRequest("Please select from the dropdown");
            }
            if (model.CityName.Any(char.IsDigit))
            {
                return BadRequest("City Name cannot contain numbers.");
            }
            if (model.CityName.Length < 5 || model.CityName.Length > 50)
            {
                return BadRequest("City Name must be between 5 and 50 characters.");
            }
            if (city == null) return NotFound();

                city.CityName = model.CityName;
                city.StateId = model.StateId;
                city.ZoneId = model.ZoneId;
                city.IsActive = model.IsActive;

                await _cityService.UpdateCityAsync(city);
                return Ok(city);
            

            //ViewBag.lstState = new SelectList(await _stateService.GetStateAsync(), "StateId", "StateName");
            //ViewBag.lstZone = new SelectList(await _zoneService.GetZoneAsync(), "ZoneId", "ZoneName");
            //return PartialView("CityForm", model);
        }
    }
}
