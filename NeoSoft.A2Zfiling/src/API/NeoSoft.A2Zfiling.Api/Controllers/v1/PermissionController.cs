using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IMediator _mediator;

        public PermissionController(ILogger<PermissionController>logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all",Name ="GetAllPermission")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get All Permission Action Initiated");

                var data = await _mediator.Send(new GetPermissionListCommand());
                _logger.LogInformation("Get All Permission Action Completed");
                return Ok(data);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred while getting permission");
                return StatusCode(500,$"An error occurred: {ex.Message}");
            }
        }

        [HttpPost(Name ="AddPermission")]
        public async Task<ActionResult> Create([FromBody] CreatePermisssionCommand model,string Token)
        {
            try
            {
                _logger.LogInformation("Create Permission Action Initiated");
                model.Token = Token;
                var data = await _mediator.Send(model);
                _logger.LogInformation("Create Permission Action Completed");
                return Ok(data);
            }
            catch(Exception ex) 
            {
                _logger.LogError("Error occurred while creating permission");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("id",Name ="GetPermissionById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data =await _mediator.Send(new GetPermissionByIdCommand() { PermissionId = id});
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex) {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("id",Name ="UpdatePermission")]
        public async Task<ActionResult> Edit([FromBody] UpdatePermissionCommand model)
        {
            try
            {
                _logger.LogInformation("Edit Permission Action Initiated");

                if(string.IsNullOrEmpty(model.ActionName))
                {
                    return BadRequest("Action name is required ");
                }
                if (string.IsNullOrEmpty(model.ControllerName))
                {
                    return BadRequest("Controller Name is required");
                }
                UpdatePermissionCommand updatePermissionCommand = new UpdatePermissionCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit Permission Action Completed");
                return Ok(data);
            }
            catch( Exception ex )
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("id",Name ="DeletePermission")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeletePermission Action Initiated");

                DeletePermissionCommand deletePermissionCommand = new DeletePermissionCommand { PermissionId =id};
                var data = await _mediator.Send(deletePermissionCommand);


                _logger.LogInformation("DeletePermission Action Completed");
                return Ok(data);
            }
            catch(Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
