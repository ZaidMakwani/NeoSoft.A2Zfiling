using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.DeleteCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.UpdateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryById;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryList;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategory")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAllCategory Initiated");
                var data = await _mediator.Send(new GetCategoryCommand());
                _logger.LogInformation("GetAllCategory Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("id", Name = "GetCategoryById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetCategoryById Initiated");
                GetCategoryByIdCommand getCityById = new GetCategoryByIdCommand() { CategoryId = id };
                var data = await _mediator.Send(getCityById);
                _logger.LogInformation("GetCategoryById Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult> Create([FromBody] CreateCategoryCommand model)
        {
            try
            {
                _logger.LogInformation("AddCategory Initiated");
                var data = await _mediator.Send(model);
                _logger.LogInformation("AddCategory Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPut("id", Name = "UpdateCategory")]
        public async Task<ActionResult> Edit([FromBody] UpdateCategoryCommand model)
        {
            try
            {
                _logger.LogInformation("UpdateCategory Initiated");
                if (string.IsNullOrEmpty(model.CategoryName))
                {
                    return BadRequest("Category Name is required.");
                }
                if (string.IsNullOrEmpty(model.ShortName))
                {
                    return BadRequest("Short Name is required.");
                }
                UpdateCategoryCommand updateCityCommand = new UpdateCategoryCommand { };
                var data = await _mediator.Send(model);
                _logger.LogInformation("UpdateCategory Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("id", Name = "DeleteCategory")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteCategory Initiated");
                DeleteCategoryCommand deleteLicense = new DeleteCategoryCommand { CategoryId = id };
                var data = await _mediator.Send(deleteLicense);
                _logger.LogInformation("DeleteCategory Completed");
                return Ok(data);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
