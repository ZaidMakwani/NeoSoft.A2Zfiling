using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById;
using System.Dynamic;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndustryController : ControllerBase
    {
        private readonly IMediator _mediator;
 

        public IndustryController(IMediator mediator)
        {
            _mediator = mediator;
  
        }

        [HttpPost(Name = "AddIndustry")]
        public async Task<ActionResult> Create([FromBody] CreateIndustryCommand createIndustryCommand)
        {

            var response = await _mediator.Send(createIndustryCommand);

            return Ok(response);
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllIndustries")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllIndustries()
        {
            try
            {

                var dtos = await _mediator.Send(new GetIndustriesListQuery());

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
     
                var dtos = await _mediator.Send(getByIdIndustryCommand);
 
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

            var response = await _mediator.Send(updateIndustryCommand);
      
            return Ok(response);
        }



        [HttpDelete(Name = "DeleteIndustry")]
        public async Task<ActionResult> Delete(int Id)
        {
         
            DeleteIndustryCommand deleteIndustryCommand = new DeleteIndustryCommand()
            {
                IndustryId = Id
            };
            var response = await _mediator.Send(deleteIndustryCommand);
           
            return Ok(response);
        }



    }
}
