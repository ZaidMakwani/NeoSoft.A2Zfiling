using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionController : ControllerBase
    {
        private readonly ILogger<UserPermissionController> _logger;
        private readonly IMediator _mediator;

        public UserPermissionController(ILogger<UserPermissionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllUserPermission")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get All User Permission Action Initiated");

                var data = await _mediator.Send(new GetUserPermissionCommand());
                _logger.LogInformation("Get All User Permission Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while getting user permission");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost(Name = "AddUserPermission")]
        public async Task<ActionResult> Create([FromBody] CreateUserPermissionCommand model)
        {
            try
            {
                _logger.LogInformation("Create UserPermission Action Initiated");

                var data = await _mediator.Send(model);
                _logger.LogInformation("Create UserPermission Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating user permission");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("id", Name = "GetUserPermissionById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data = await _mediator.Send(new GetUserPermissionByIdCommand() { UserPermissionId = id });
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("id", Name = "UpdateUserPermission")]
        public async Task<ActionResult> Edit([FromBody] UpdateUserPermissionCommand model)
        {
            try
            {
                _logger.LogInformation("Edit User Permission Action Initiated");

              
                UpdateUserPermissionCommand updatePermissionCommand = new UpdateUserPermissionCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit User Permission Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpDelete("id", Name = "DeleteUserPermission")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteUserPermission Action Initiated");

                DeleteUserPermissionCommand deletePermissionCommand = new DeleteUserPermissionCommand { UserPermissionId = id };
                var data = await _mediator.Send(deletePermissionCommand);


                _logger.LogInformation("DeleteUserPermission Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
