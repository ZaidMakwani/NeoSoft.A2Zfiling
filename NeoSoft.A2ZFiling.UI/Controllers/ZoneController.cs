using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class ZoneController : Controller
    {
        private readonly ILogger<ZoneController> _logger;
        private readonly IZoneService _zoneService;

        public ZoneController(ILogger<ZoneController> logger, IZoneService zoneService)
        {
            _logger = logger;
            _zoneService = zoneService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllZone()
        {
            try
            {
                _logger.LogInformation("Zone Action Initiated");
                var response = await _zoneService.GetZoneAsync();
                _logger.LogInformation("Zone Action Completed");
               // return View(response);
                return PartialView("_ReadAllZones", response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating zone.");
                return StatusCode(500, "An error occurred while creating zone.");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            return PartialView("_ZonePartial");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ZoneVM model)
        {
            try
            {
                _logger.LogInformation("Create Zone Action Initiated");

                if (string.IsNullOrEmpty(model.ZoneName))
                {
                    return BadRequest("Please enter a valid zone name.");
                }
                if (model.ZoneName.Any(char.IsDigit))
                {
                    return BadRequest("Zone Name cannot contain numbers.");
                }

                var existingZone =( await _zoneService.GetZoneAsync()).Where(x=>x.ZoneName.ToLower() ==model.ZoneName.ToLower()).FirstOrDefault();
                if (existingZone != null)
                {
                    return BadRequest("Zone with this name already exists.");
                }
                var response = await _zoneService.CreateZoneAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create zone: Response was null.");
                    return BadRequest("Failed to create zone.");
                }
                else
                {
                    _logger.LogInformation("Create Zone Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating zone.");
                return StatusCode(500, "An error occurred while creating zone.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteZone(int id)
        {
            try
            {
                _logger.LogInformation("Delete Zone Action Initiated");
                var response = await _zoneService.DeleteZoneAsync(id);
                _logger.LogInformation("Delete Zone Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating zone.");
                return StatusCode(500, "An error occurred while creating zone.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditZone(int id)
        {
            try
            {
                _logger.LogInformation("Get EditZone Initiated");

                var getById = await _zoneService.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation("Get EditZone Completed");
                    return PartialView("_EditZone", getById); 
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
        public async Task<IActionResult> EditZone( ZoneVM model)
        {
             try
            {
                _logger.LogInformation("Edit Zone Action Initiated");

                if (string.IsNullOrEmpty(model.ZoneName))
                {
                    return BadRequest("Please enter a valid zone name.");
                }
                if (model.ZoneName.Any(char.IsDigit))
                {
                    return BadRequest("Zone Name cannot contain numbers.");
                }
                var existingZone = (await _zoneService.GetZoneAsync()).Where(x => x.ZoneName.ToLower() == model.ZoneName.ToLower()).FirstOrDefault();
                if (existingZone != null)
                {
                    return BadRequest("Zone with this name already exists.");
                }
                var response = await _zoneService.UpdateZoneAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit zone: Response was null.");
                    return BadRequest("Failed to edit zone.");
                }
                else
                {
                    _logger.LogInformation("Edit Zone Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing zone.");
                return StatusCode(500, "An error occurred while editing zone.");
            }
        }
    }
}
