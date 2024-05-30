using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleDetails;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RolesController> _logger;

        public RolesController(IMediator mediator, ILogger<RolesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllRoles")]
        public async Task<ActionResult> GetAllRoles()
        {
            _logger.LogInformation("GetAllRoles Initiated");
            var dtos = await _mediator.Send(new GetRolesListQuery());
            _logger.LogInformation("GetAllRoles Completed");
            return Ok(dtos);
        }

        [HttpPost(Name = "AddRoles")]
        public async Task<ActionResult> Create([FromBody] CreateRolesCommand createRolesCommand)
        {
            var response = await _mediator.Send(createRolesCommand);
            return Ok(response);
        }
        [HttpGet(Name ="GetRoleById")]
        public async Task<ActionResult> GetRoleById(int id) 
        {
            var getRoleId=new GetRoleDetailsQuery() { RoleId=id};
            return Ok(await _mediator.Send(getRoleId));
        }

        [HttpPut(Name ="UpdateRole")]
        public async Task<ActionResult> Update([FromBody] UpdateRolesCommand updateRolesCommand)
        {
            var response = await _mediator.Send(updateRolesCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteRoles")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteRolesCommand = new DeleteRolesCommand() { RoleId = id };
            await _mediator.Send(deleteRolesCommand);
            return Ok("Role deleted successfully");
        }
    }
}
