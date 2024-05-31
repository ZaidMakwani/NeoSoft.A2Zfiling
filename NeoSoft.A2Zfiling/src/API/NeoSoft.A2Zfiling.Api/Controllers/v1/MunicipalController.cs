using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.DeleteMunicipal;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MunicipalController : ControllerBase
    {
       
            private readonly IMediator _mediator;
            private readonly ILogger<MunicipalController> _logger;

            public MunicipalController(IMediator mediator, ILogger<MunicipalController> logger)
            {
                _mediator = mediator;
                _logger = logger;
            }

        [HttpGet("all", Name = "GetAllMunicipal")]
        public async Task<ActionResult> GetAllMunicipal()
        {
            _logger.LogInformation("GetAllMunicipal Initiated");
            var dtos = await _mediator.Send(new GetMunicipalListQuery());
            _logger.LogInformation("GetAllMunicipal Completed");
            return Ok(dtos);
        }

        [HttpPost(Name = "AddMunicipal")]
            public async Task<ActionResult> Create([FromBody] CreateMunicipalCommand createMunicipalCommand)
            {
                var response = await _mediator.Send(createMunicipalCommand);
                return Ok(response);
            }

        [HttpGet("{id}",Name = "GetMunicipalCorpById")]
        public async Task<ActionResult> GetMunicipalCorpById(int id)
        {
            var getMunicipalId = new GetMunicipalDetailsQuery() { MunicipalId = id };
            return Ok(await _mediator.Send(getMunicipalId));
        }
        [HttpPut(Name = "UpdateMunicipal")]
        public async Task<ActionResult> Update([FromBody] UpdateMunicipalCommand updateMunicipalCommand)
        {
            var response = await _mediator.Send(updateMunicipalCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteMunicipal")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteMunicipalCommand = new DeleteMunicipalCommand() { MunicipalId = id };
            await _mediator.Send(deleteMunicipalCommand);
            return Ok("Municipal deleted successfully");
        }
    }
    }

