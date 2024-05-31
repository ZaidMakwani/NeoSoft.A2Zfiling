using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CompanyController(IMediator mediator, ILogger<CompanyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddCompany")]
        public async Task<ActionResult> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var response = await _mediator.Send(createCompanyCommand);
            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllCompanies")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCompanies()
        {
            try
            {
                _logger.LogInformation("GetAllCompanies Initiated");
                var dtos = await _mediator.Send(new GetCompaniesListQuery());
                _logger.LogInformation("GetAllIndustries Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet(Name = "GetCompaniesById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetCompaniesById(int Id)
        {
            try
            {
                GetCompaniesByIdQuery getByIdCompanyCommand = new GetCompaniesByIdQuery()
                {
                    CompanyId = Id
                };
                _logger.LogInformation("GetCompaniesById Initiated");
                var dtos = await _mediator.Send(getByIdCompanyCommand);
                _logger.LogInformation("GetCompaniesById Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpPut(Name = "UpdateCompany")]
        public async Task<ActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            var response = await _mediator.Send(updateCompanyCommand);
            return Ok(response);
        }




        [HttpDelete(Name = "DeleteCompany")]
        public async Task<ActionResult> Delete(int Id)
        {
            DeleteCompanyCommand deleteCompanyCommand = new DeleteCompanyCommand()
            {
                CompanyId = Id
            };
            var response = await _mediator.Send(deleteCompanyCommand);
            return Ok(response);
        }
    }
}
