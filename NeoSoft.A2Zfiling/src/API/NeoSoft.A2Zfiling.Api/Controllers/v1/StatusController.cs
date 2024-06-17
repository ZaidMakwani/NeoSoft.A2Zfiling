using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;
using NeoSoft.A2Zfiling.Application.Features.Statuses.Command.CreateStatus;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.DeleteStatus;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.UpdateStatus;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusList;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusListById;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StatusController> _logger;

        public StatusController(IMediator mediator, ILogger<StatusController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllStatus")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get All Status Action Initiated");

                var data = await _mediator.Send(new StatusListCommand());
                _logger.LogInformation("Get All Status Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while getting status");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("id", Name = "GetStatusById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data = await _mediator.Send(new StatusListByIdCommand() { StatusId= id });
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost(Name = "AddStatus")]
        public async Task<ActionResult> Create([FromBody] CreateStatusCommand model)
        {
            try
            {
                _logger.LogInformation("Create Status Action Initiated");

                var data = await _mediator.Send(model);
                _logger.LogInformation("Create Status Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating status");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("id", Name = "UpdateStatus")]
        public async Task<ActionResult> Edit([FromBody] UpdateStatusCommand model)
        {
            try
            {
                _logger.LogInformation("Edit Status Action Initiated");

                if (string.IsNullOrEmpty(model.StatusName))
                {
                    return BadRequest("Action name is required ");
                }
               
                UpdateStatusCommand updatePermissionCommand = new UpdateStatusCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit Status Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("id", Name = "DeleteStatus")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteStatus Action Initiated");

                DeleteStatusCommand deleteStatusCommand = new DeleteStatusCommand { StatusId = id };
                var data = await _mediator.Send(deleteStatusCommand);


                _logger.LogInformation("DeleteStatus Action Completed");
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
