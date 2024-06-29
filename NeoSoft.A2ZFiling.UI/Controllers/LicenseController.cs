using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NuGet.Packaging;
using System.ComponentModel;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class LicenseController : Controller
    {
        private readonly ILogger<LicenseController> _logger;
        private readonly ILicenseService _licenseService;
        private readonly ICategoryService _categoryService;

        public LicenseController(ILogger<LicenseController> logger, ILicenseService licenseService, ICategoryService categoryService)
        {
            _licenseService = licenseService;
            _logger = logger;
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAll License Action Initiated");

                var response = await _licenseService.GetLicenseAsync();
                _logger.LogInformation("GetAll License Action Completed");
                return PartialView("_GetAllLicense",response);
            }

            catch (Exception ex)
            {
                _logger.LogError("An error occurred whike getting all license");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetCategoryAsync();
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
            return PartialView("_CreateLicense");
        }

        [HttpPost]
        public async Task<IActionResult> Create(LicenseVM model)
        {
            try
            {
                _logger.LogInformation("Create License  Action  Initiated");

                if (string.IsNullOrEmpty(model.LicenseName))
                {
                    return BadRequest("Please enter a valid license name.");
                }

                if (string.IsNullOrEmpty(model.ShortName))
                {
                    return BadRequest("Please enter a valid short name.");
                }
                if ((model.LicenseName.Any(char.IsDigit)) || (model.ShortName.Any(char.IsDigit)))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }

                if (model.CategoryId == 0)
                {
                    return BadRequest("Please select a Category.");
                }

                if (model.ShortList == default)
                {
                    return BadRequest("Please select a ShortList .");
                }
                if (model.LicenseName.Length < 5 || model.LicenseName.Length > 50)
                {
                    return BadRequest("License Name must be between 5 and 50 characters.");
                }
                if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
                {
                    return BadRequest("Short Name must be between 2 and 10 characters.");
                }
                var existingLicense = (await _licenseService.GetLicenseAsync()).Where(x => x.LicenseName.ToLower() == model.LicenseName.ToLower() || x.ShortName.ToLower()==model.ShortName.ToLower()).FirstOrDefault();
                if (existingLicense != null)
                {
                    return BadRequest("License with this name already exists.");
                }
                var response = await _licenseService.CreateLicenseAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create license : Response was null.");
                    return BadRequest("Failed to create license .");
                }
                else
                {
                    _logger.LogInformation("Create License  Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating license .");
                return StatusCode(500, "An error occurred while creating license .");
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete License Action Initiated");
                var response = await _licenseService.DeleteLicenseAsync(id);
                _logger.LogInformation("Delete License Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating license .");
                return StatusCode(500, "An error occurred while creating license .");
            }
        }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                try
                {
                    _logger.LogInformation(" EditLicense Initiated");

                    var getById = await _licenseService.GetByIdAsync(id);

                    if (getById != null)
                    {

                        _logger.LogInformation(" EditLicense Completed");
                    var category = await _categoryService.GetCategoryAsync();
                    ViewBag.Categories = new SelectList(category, "CategoryId", "CategoryName", getById.CategoryId);

                    var model = new LicenseVM
                    {
                        LicenseId = getById.LicenseId,
                        LicenseName = getById.LicenseName,
                        ShortName = getById.ShortName,
                        CategoryId = getById.CategoryId,
                        ShortList = getById.ShortList,
                        IsActive=true,
                    };

                    return PartialView("_EditLicense", model);
                    }
                    else
                    {
                        _logger.LogError("The License is not found");
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while retrieving license .");
                    return StatusCode(500, "An error occurred while retrieving license .");
                }
            }

        [HttpPost]
        public async Task<IActionResult> Update(LicenseVM model)
        {
            try
            {
                _logger.LogInformation("Update License  Action  Initiated");

                if (string.IsNullOrEmpty(model.LicenseName))
                {
                    return BadRequest("Please enter a valid license name.");
                }

                if (string.IsNullOrEmpty(model.ShortName))
                {
                    return BadRequest("Please enter a valid short name.");
                }
                if ((model.LicenseName.Any(char.IsDigit)) || (model.ShortName.Any(char.IsDigit)))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }

                if (model.CategoryId == 0)
                {
                    return BadRequest("Please select a Category.");
                }
                //if (!Enum.IsDefined(typeof(ShortList), model.ShortList))
                //{
                //    return BadRequest("Please select a valid ShortList value.");
                //}
                if (model.LicenseName.Length < 5 || model.LicenseName.Length > 50)
                {
                    return BadRequest("License Name must be between 5 and 50 characters.");
                }
                if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
                {
                    return BadRequest("Short Name must be between 2 and 10 characters.");
                }
                var response = await _licenseService.UpdateLicenseAsync(model);
                if (response == null)
                {
                    return BadRequest("Failed to update license.");
                }
                var categories = await _categoryService.GetCategoryAsync();
                ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", model.CategoryId);
                _logger.LogInformation("Update License  Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating license.");
                return StatusCode(500, "An error occurred while updating license.");
            }
        }


    }
}

