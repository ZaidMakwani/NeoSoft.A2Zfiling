using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;
        private readonly IStatusService _statusService;

        public StatusController(ILogger<StatusController> logger, IStatusService statusService)
        {
            _logger = logger;
           _statusService = statusService;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll Status Action Initiated");

                var response = await _statusService.GetStatusAsync();
                _logger.LogInformation("GetAll Status Action Completed");
                //return View(response);
                return PartialView("_GetAllStatus", response);
            }

            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all permission");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            return PartialView("_CreateStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Create(StatusVM model)
        {
            try
            {
                _logger.LogInformation("Create Status Action  Initiated");

                if (string.IsNullOrEmpty(model.StatusName))
                {
                    return BadRequest("Please enter a valid Status name.");
                }
                if (model.StatusName.Any(char.IsDigit))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }
                var existingCategory = (await _statusService.GetStatusAsync()).Where(x => x.StatusName.ToLower() == model.StatusName.ToLower()).FirstOrDefault();
                if (existingCategory != null)
                {
                    return BadRequest("Status with this name already exists.");
                }
                var response = await _statusService.CreateStatusAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create status : Response was null.");
                    return BadRequest("Failed to create status .");
                }
                else
                {
                    _logger.LogInformation("Create Status Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating status .");
                return StatusCode(500, "An error occurred while creating status .");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                _logger.LogInformation("Get EditStatus Initiated");

                var getById = await _statusService.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation("Get EditStatus Completed");
                    return PartialView("_EditStatus", getById);
                }
                else
                {
                    _logger.LogError("The Status is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving status details.");
                return StatusCode(500, "An error occurred while retrieving status details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(StatusVM model)
        {
            try
            {
                _logger.LogInformation("Edit Status Action Initiated");

                if (string.IsNullOrEmpty(model.StatusName))
                {
                    return BadRequest("Please enter a valid Status name.");
                }

                if (model.StatusName.Any(char.IsDigit))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }
                var response = await _statusService.UpdateStatusAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit status: Response was null.");
                    return BadRequest("Failed to edit status.");
                }
                else
                {
                    _logger.LogInformation("Edit Status Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing status.");
                return StatusCode(500, "An error occurred while editing status.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete Status Action Initiated");
                var response = await _statusService.DeleteStatusAsync(id);
                _logger.LogInformation("Delete Status Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating status.");
                return StatusCode(500, "An error occurred while creating status.");
            }
        }

    }

}
