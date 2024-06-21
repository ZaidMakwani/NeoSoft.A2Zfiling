using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Create;
using NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Delete;
using NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Edit;
using NeoSoft.A2Zfiling.Application.Features.License_Master.Queries.GetAllLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class LicenseMasterController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly ILogger<LicenseMasterController> _logger;

        public LicenseMasterController(IMediator mediator,ILogger<LicenseMasterController> logger)
        {
            _logger = logger;
            _mediator = mediator;   
        }

        [HttpPost]
        public async Task<ActionResult> CreateLicenseMapping([FromBody] CreateLicenseMappingCommand createLicenseMappingCommand)
        {
            var response = await _mediator.Send(createLicenseMappingCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllLicenseMaster()
        {
            var response = await _mediator.Send( new GetAllLicenseMasterQuery());
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateLicenseMaster([FromBody] UpdateLicenseMasterCommand updateLicenseMasterCommand)
        {
            var response = await _mediator.Send(updateLicenseMasterCommand);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteLicenseMaster(int id)
        {
            var deleteCommand = new DeleteLicenseMasterCommand() { LicenseMasterId = id };
            await _mediator.Send(deleteCommand);
            return Ok("Delete Successfully");
        }
    }
}
