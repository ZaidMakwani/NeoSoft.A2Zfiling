using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LicenseTypeController> _logger;

        public LicenseTypeController(IMediator mediator, ILogger<LicenseTypeController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllLicense")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("GetAllLicense Initiated");
                var data = await _mediator.Send(new GetLicenseTypeListCommand());
                _logger.LogInformation("GetAllLicense Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "AddLicense")]
        public async Task<ActionResult> Create([FromBody] CreateLicenseTypeCommand model)
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

        [HttpGet("id", Name = "GetLicenseById")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation("GetLicenseById Initiated");
                GetLicenseTypeByIdCommand getCityById = new GetLicenseTypeByIdCommand() { LicenseTypeId = id };
                var data = await _mediator.Send(getCityById);
                _logger.LogInformation("GetLicenseById Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("id", Name = "UpdateLicenseType")]
        public async Task<ActionResult> Edit([FromBody] UpdateLicenseTypeCommand model)
        {
            try
            {
                _logger.LogInformation("UpdateLicenseType Initiated");
                if (string.IsNullOrEmpty(model.LicenseName))
                {
                    return BadRequest("License Name is required.");
                }
                if (string.IsNullOrEmpty(model.Description))
                {
                    return BadRequest("License Description is required.");
                }
                UpdateLicenseTypeCommand updateCityCommand = new UpdateLicenseTypeCommand { };
                var data = await _mediator.Send(model);
                _logger.LogInformation("UpdateLicenseType Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("id", Name = "DeleteLicenseType")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("DeleteLicenseType Initiated");
                DeleteLicenseTypeCommand deleteLicense = new DeleteLicenseTypeCommand { LicenseTypeId = id };
                var data = await _mediator.Send(deleteLicense);
                _logger.LogInformation("DeleteLicenseType Completed");
                return Ok(data);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
