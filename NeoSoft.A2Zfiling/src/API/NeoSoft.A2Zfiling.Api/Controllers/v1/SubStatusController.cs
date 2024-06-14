using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid;
using NeoSoft.A2Zfiling.Application.Features.Statuses.Command.CreateStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.CreateSubStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.UpdateSubStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusList;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusListById;
using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubStatusController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SubStatusController> _logger;

        public SubStatusController(IMediator mediator, ILogger<SubStatusController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetSubStatus")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get SubStatus Action Initiated");

                var data = await _mediator.Send(new SubStatusCommand());
                _logger.LogInformation("Get SubStatus Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while getting sub status ");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("id", Name = "SubStatusById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data = await _mediator.Send(new SubStatusListByIdCommand() { SubStatusId = id });
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost(Name = "AddSubStatus")]
        public async Task<ActionResult> Create([FromBody] CreateSubStatusCommand model)
        {
            try
            {
                _logger.LogInformation("Create Sub Status Action Initiated");

                var data = await _mediator.Send(model);
                _logger.LogInformation("Create Sub  Status Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating status");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("id", Name = "UpdateSubStatus")]
        public async Task<ActionResult> Edit([FromBody] UpdateSubStatusCommand model)
        {
            try
            {
                _logger.LogInformation("Edit SubStatus Action Initiated");


                UpdateSubStatusCommand updateLicenseCommand = new UpdateSubStatusCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit SubStatus Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("id", Name = "DeleteSubStatus")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteSubStatus Action Initiated");

                DeleteSubStatusCommand deleteSubStatuseCommand = new DeleteSubStatusCommand { SubStatusId = id };
                var data = await _mediator.Send(deleteSubStatuseCommand);


                _logger.LogInformation("DeleteSubStatus Action Completed");
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
