using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries;
using System.Dynamic;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public IndustryController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddIndustry")]
        public async Task<ActionResult> Create([FromBody] CreateIndustryCommand createIndustryCommand)
        {
            _logger.LogInformation("Add Industries Initiated"); 
            var response = await _mediator.Send(createIndustryCommand);
            _logger.LogInformation("Add Industries Completed");
            return Ok(response);
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllIndustries")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllIndustries()
        {
            try
            {
                _logger.LogInformation("GetAllIndustries Initiated");
                var dtos = await _mediator.Send(new GetIndustriesListQuery());
                _logger.LogInformation("GetAllIndustries Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }
           
        }


        [HttpGet(Name = "GetIndustriesById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetIndustriesById(int Id)
        {
            try
            {
                GetIndustriesByIdQuery getByIdIndustryCommand = new GetIndustriesByIdQuery()
                {
                    IndustryId = Id
                };
                _logger.LogInformation("GetIndustriesById Initiated");
                var dtos = await _mediator.Send(getByIdIndustryCommand);
                _logger.LogInformation("GetIndustriesById Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }



        [HttpPut(Name = "UpdateIndustry")]
        public async Task<ActionResult> Update([FromBody] UpdateIndustryCommand updateIndustryCommand)
        {
            _logger.LogInformation("Updating Industries Initiated");
            var response = await _mediator.Send(updateIndustryCommand);
            _logger.LogInformation("Updating Industries Initiated");
            return Ok(response);
        }



        [HttpDelete(Name = "DeleteIndustry")]
        public async Task<ActionResult> Delete(int Id)
        {
            _logger.LogInformation("Deleting Industries Initiated");
            DeleteIndustryCommand deleteIndustryCommand = new DeleteIndustryCommand()
            {
                IndustryId = Id
            };
            var response = await _mediator.Send(deleteIndustryCommand);
            _logger.LogInformation("Deleting Industries Initiated");
            return Ok(response);
        }
    }
}
