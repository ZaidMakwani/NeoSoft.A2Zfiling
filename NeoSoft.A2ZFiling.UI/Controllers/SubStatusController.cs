using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class SubStatusController : Controller
    {
        private readonly ILogger<SubStatusController> _logger;
        private readonly ISubStatusService _subStatusService;
        private readonly IStatusService _statusService;

        public SubStatusController(ILogger<SubStatusController> logger, IStatusService statusService,ISubStatusService subStatusService)
        {
            _statusService = statusService;
            _subStatusService = subStatusService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll SubStatus Action Initiated");

                var response = await _subStatusService.GetSubStatusAsync();
                _logger.LogInformation("GetAll SubStatus Action Completed");
                return PartialView("_GetAllSubStatus", response);
            }

            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all sub status");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var status = await _statusService.GetStatusAsync();
            ViewBag.SubStatuses = new SelectList(status, "StatusId", "StatusName");
            return PartialView("_CreateSubStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubStatusVM model)
        {
            try
            {
                _logger.LogInformation("Create SubStatus  Action  Initiated");

                if (string.IsNullOrEmpty(model.SubStatusName))
                {
                    return BadRequest("Please enter a valid license name.");
                }
                //if (model.SubStatusName.Any(char.IsDigit))
                //{
                //    return BadRequest(" Name cannot contain numbers.");
                //}

                if (model.StatusId == 0)
                {
                    return BadRequest("Please select a Status.");
                }
                var existingLicense = (await _subStatusService.GetSubStatusAsync()).Where(x => x.SubStatusName.ToLower() == model.SubStatusName.ToLower()).FirstOrDefault();
                if (existingLicense != null)
                {
                    return BadRequest("SubStatus with this name already exists.");
                }
                var response = await _subStatusService.CreateSubStatusAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create sub status : Response was null.");
                    return BadRequest("Failed to create sub status .");
                }
                else
                {
                    _logger.LogInformation("Create License  Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating sub status .");
                return StatusCode(500, "An error occurred while creating sub status .");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                _logger.LogInformation(" EditSubStatus Initiated");

                var getById = await _subStatusService.GetByIdAsync(id);

                if (getById != null)
                {

                    _logger.LogInformation(" EditSubStatus Completed");
                    var status = await _statusService.GetStatusAsync();
                    ViewBag.Statuses = new SelectList(status, "StatusId", "StatusName", getById.StatusId);

                    var model = new SubStatusVM
                    {
                        SubStatusId = getById.SubStatusId,
                        SubStatusName = getById.SubStatusName,
                        StatusId = getById.StatusId,
                        IsActive = true,
                    };

                    return PartialView("_EditSubStatus", model);
                }
                else
                {
                    _logger.LogError("The Sub Status is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving sub status .");
                return StatusCode(500, "An error occurred while retrieving sub status .");
            }
        }


        [HttpPost]
        public async Task<IActionResult> Update(SubStatusVM model)
        {
            try
            {
                _logger.LogInformation("Update SubStatus  Action  Initiated");

                if (string.IsNullOrEmpty(model.SubStatusName))
                {
                    return BadRequest("Please enter a valid sub status name.");
                }
                //if (model.SubStatusName.Any(char.IsDigit))
                //{
                //    return BadRequest(" Name cannot contain numbers.");
                //}

                if (model.StatusId == 0)
                {
                    return BadRequest("Please select a Status.");
                }

                var response = await _subStatusService.UpdateSubStatusAsync(model);
                if (response == null)
                {
                    return BadRequest("Failed to update sub status.");
                }
                var status = await _statusService.GetStatusAsync();
                ViewBag.Statuses = new SelectList(status, "StatusId", "StatusName", model.StatusId);
                _logger.LogInformation("Update SubStatus  Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating sub status.");
                return StatusCode(500, "An error occurred while updating substatus.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete SubStatus Action Initiated");
                var response = await _subStatusService.DeleteSubStatusAsync(id);
                _logger.LogInformation("Delete SubStatus Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating SubStatus .");
                return StatusCode(500, "An error occurred while creating SubStatus .");
            }
        }

    }
}
