using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LicenseController> _logger;

        public LicenseController(IMediator mediator, ILogger<LicenseController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet("all", Name = "GetLicense")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Get All License Action Initiated");

                var data = await _mediator.Send(new LicenseListCommand());
                _logger.LogInformation("Get AllLicense Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while getting license ");
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost(Name = "Add")]
        public async Task<ActionResult> Create([FromBody] CreateLicenseCommand model)
        {
            try
            {
                _logger.LogInformation("AddLicense Initiated");
                var data = await _mediator.Send(model);
                _logger.LogInformation("AddLicense Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("id", Name = "LicenseById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetById Action Initiated");

                var data = await _mediator.Send(new LicenseListByIdCommand() { LicenseId = id });
                _logger.LogInformation("GetById Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPut("id", Name = "UpdateLicense")]
        public async Task<ActionResult> Edit([FromBody] UpdateLicenseCommand model)
        {
            try
            {
                _logger.LogInformation("Edit License Action Initiated");


                UpdateLicenseCommand updateLicenseCommand = new UpdateLicenseCommand { };
                var data = await _mediator.Send(model);

                _logger.LogInformation("Edit License Action Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("id", Name = "DeleteLicense")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteLicense Action Initiated");

                DeleteLicenseCommand deleteLicenseCommand = new DeleteLicenseCommand { LicenseId = id };
                var data = await _mediator.Send(deleteLicenseCommand);


                _logger.LogInformation("DeleteLicense Action Completed");
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
