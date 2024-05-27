using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class CityController : Controller
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityService _cityService;

        public CityController(ILogger<CityController> logger, ICityService cityService)
        {
            _logger = logger;
             _cityService = cityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            try
            {
                _logger.LogInformation("City Action Initiated");
                var response = await _cityService.GetCityAsync();
                _logger.LogInformation("City Action Completed");
                return View(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            return PartialView("_CreateCity");
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
            try
            {
                _logger.LogInformation("Get EditZone Initiated");

                var getById = await _cityService.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation("Get EditZone Completed");
                    return PartialView("_EditCity", getById);
                }
                else
                {
                    _logger.LogError("The Zone is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving zone details.");
                return StatusCode(500, "An error occurred while retrieving zone details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditCity(CityVM model)
        {
            try
            {
                _logger.LogInformation("Edit City Action Initiated");

                if (string.IsNullOrEmpty(model.CityName))
                {
                    return BadRequest("Please enter a valid city name.");
                }
                if (model.CityName.Any(char.IsDigit))
                {
                    return BadRequest("City Name cannot contain numbers.");
                }
                var existingCity = (await _cityService.GetCityAsync()).Where(x => x.CityName.ToLower() == model.CityName.ToLower()).FirstOrDefault();
                if (existingCity != null)
                {
                    return BadRequest("City with this name already exists.");
                }
                var response = await _cityService.UpdateCityAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit city: Response was null.");
                    return BadRequest("Failed to edit city.");
                }
                else
                {
                    _logger.LogInformation("Edit City Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing city.");
                return StatusCode(500, "An error occurred while editing city.");
            }
        }
    }
}
