using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class LicenseTypeController : Controller
    {
        private readonly ILogger<LicenseTypeController> _logger;
        private readonly ILicenseType _licenseType;

        public LicenseTypeController(ILogger<LicenseTypeController> logger, ILicenseType licenseType)
        {
            _licenseType = licenseType;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("License Type Action Initiated");
                var response = await _licenseType.GetLicenseTypeAsync();
                _logger.LogInformation("License Type Action Completed");
                return View(response);
               // return PartialView("_GetAllLicenseType", response);
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
            return PartialView("_CreateLicenseType");
        }

        [HttpPost]
        public async Task<IActionResult> Create(LicenseTypeVM model)
        {
            try
            {
                _logger.LogInformation("Create License Type Action  Initiated");

                if (string.IsNullOrEmpty(model.LicenseName))
                {
                    return BadRequest("Please enter a valid license name.");
                }

                if (string.IsNullOrEmpty(model.Description))
                {
                    return BadRequest("Please enter a valid description name.");
                }
                if (model.LicenseName.Any(char.IsDigit))
                {
                    return BadRequest("License Name cannot contain numbers.");
                }
                var existingCity = (await _licenseType.GetLicenseTypeAsync()).Where(x => x.LicenseName.ToLower() == model.LicenseName.ToLower()).FirstOrDefault();
                if (existingCity != null)
                {
                    return BadRequest("City with this name already exists.");
                }
                var response = await _licenseType.CreateLicenseTypeAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create license type: Response was null.");
                    return BadRequest("Failed to create license type.");
                }
                else
                {
                    _logger.LogInformation("Create License Type Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating license type.");
                return StatusCode(500, "An error occurred while creating license type.");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete License Type Action Initiated");
                var response = await _licenseType.DeleteLicenseTypeAsync(id);
                _logger.LogInformation("Delete License Type Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating license type.");
                return StatusCode(500, "An error occurred while creating license type.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                _logger.LogInformation("Edit License Type Initiated");

                var getById = await _licenseType.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation("Edit License Type Completed");
                    return PartialView("_EditLicenseType", getById);
                }
                else
                {
                    _logger.LogError("The License Type is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving license type details.");
                return StatusCode(500, "An error occurred while retrieving license type details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LicenseTypeVM model)
        {
            try
            {
                _logger.LogInformation("Edit License Type Action Initiated");
                if (string.IsNullOrEmpty(model.LicenseName))
                {
                    return BadRequest("Please enter a valid license name.");
                }

                if (string.IsNullOrEmpty(model.Description))
                {
                    return BadRequest("Please enter a valid description name.");
                }
                if (model.LicenseName.Any(char.IsDigit))
                {
                    return BadRequest("License Name cannot contain numbers.");
                }
                //var existingCity = (await _licenseType.GetLicenseTypeAsync()).Where(x => x.LicenseName.ToLower() == model.LicenseName.ToLower()).FirstOrDefault();
                //if (existingCity != null)
                //{
                //    return BadRequest("License Type with this name already exists.");
                //}
                var response = await _licenseType.UpdateLicenseTypeAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit license type: Response was null.");
                    return BadRequest("Failed to edit license type.");
                }
                else
                {
                    _logger.LogInformation("Edit License Type Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing license type.");
                return StatusCode(500, "An error occurred while editing license type.");
            }
        }

        }
}
