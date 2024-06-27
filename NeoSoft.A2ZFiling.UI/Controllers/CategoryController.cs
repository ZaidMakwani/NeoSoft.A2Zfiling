using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class CategoryController : Controller
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
        {
          _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Category Action Initiated");
                var response = await _categoryService.GetCategoryAsync();
                _logger.LogInformation("Category Action Completed");
                return PartialView("_GetAllCategory",response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating category.");
                return StatusCode(500, "An error occurred while creating category.");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            //return View();
            return PartialView("_CreateCategory");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM model)
        {
            try
            {
                _logger.LogInformation("Create Category Action  Initiated");

                if (string.IsNullOrEmpty(model.CategoryName))
                {
                    return BadRequest("Please enter a valid Category name.");
                }

                if (string.IsNullOrEmpty(model.ShortName))
                {
                    return BadRequest("Please enter a valid short name.");
                }
                if ((model.CategoryName.Any(char.IsDigit)) || (model.ShortName.Any(char.IsDigit)))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }
                if (model.CategoryName.Length < 5 || model.CategoryName.Length > 50)
                {
                    return BadRequest("Category Name must be between 5 and 50 characters.");
                }
                if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
                {
                    return BadRequest("Category Name must be between 2 and 10 characters.");
                }
                var existingCategory = (await _categoryService.GetCategoryAsync()).Where(x => x.CategoryName.ToLower() == model.CategoryName.ToLower() || x.ShortName.ToLower()==model.ShortName.ToLower()).FirstOrDefault();
                if (existingCategory != null)
                {
                    return BadRequest("Category with this name already exists.");
                }
                var response = await _categoryService.CreateCategoryAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to create category : Response was null.");
                    return BadRequest("Failed to create category .");
                }
                else
                {
                    _logger.LogInformation("Create Category Action Completed");
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating category .");
                return StatusCode(500, "An error occurred while creating category .");
            }

        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("Delete Category Action Initiated");
                var response = await _categoryService.DeleteCategoryAsync(id);
                _logger.LogInformation("Delete Category Action Completed");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating category.");
                return StatusCode(500, "An error occurred while creating category.");
            }
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                _logger.LogInformation("Get EditCategory Initiated");

                var getById = await _categoryService.GetByIdAsync(id);

                if (getById != null)
                {
                    _logger.LogInformation("Get EditCategory Completed");
                    return PartialView("_EditCategory", getById);
                }
                else
                {
                    _logger.LogError("The Category is not found");
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving category details.");
                return StatusCode(500, "An error occurred while retrieving category details.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryVM model)
        {
            try
            {
                _logger.LogInformation("Edit Category Action Initiated");

                if (string.IsNullOrEmpty(model.CategoryName))
                {
                    return BadRequest("Please enter a valid Category name.");
                }

                if (string.IsNullOrEmpty(model.ShortName))
                {
                    return BadRequest("Please enter a valid short name.");
                }
                if ((model.CategoryName.Any(char.IsDigit)) || (model.ShortName.Any(char.IsDigit)))
                {
                    return BadRequest(" Name cannot contain numbers.");
                }
                if (model.CategoryName.Length < 5 || model.CategoryName.Length > 50)
                {
                    return BadRequest("Category Name must be between 5 and 50 characters.");
                }
                if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
                {
                    return BadRequest("Category Name must be between 2 and 10 characters.");
                }
                //var existingCategory = (await _categoryService.GetCategoryAsync()).Where(x => x.CategoryName.ToLower() == model.CategoryName.ToLower()).FirstOrDefault();
                //if (existingCategory != null)
                //{
                //    return BadRequest("Category with this name already exists.");
                //}
                var response = await _categoryService.UpdateCategoryAsync(model);
                if (response == null)
                {
                    _logger.LogError("Failed to edit category: Response was null.");
                    return BadRequest("Failed to edit category.");
                }
                else
                {
                    _logger.LogInformation("Edit Category Action Completed");
                    // Instead of returning Ok(), return a JSON object
                    //return Json(new { success = true });
                    return Ok(response);

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while editing category.");
                return StatusCode(500, "An error occurred while editing category.");
            }
        }
    }
}
