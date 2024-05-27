
﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.CreateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ZoneController> _logger;

        public ZoneController(IMediator mediator, ILogger<ZoneController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("all", Name = "GetAllZone")]
        public async Task<ActionResult> GetAllZone()
        {
            try
            {
                _logger.LogInformation("GetAllZones Initiated");
                var data = await _mediator.Send(new GetListQuery());
                _logger.LogInformation("GetAllZones Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost(Name = "AddZone")]
        public async Task<ActionResult> CreateZone([FromBody] CreateZoneCommand model)
        {
            try
            {
                _logger.LogInformation("AddZones Initiated");
                var response = await _mediator.Send(model);
                _logger.LogInformation("AddZones Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("id", Name = "DeleteZone")]
        public async Task<ActionResult> DeleteZone(int id)
        {
            try
            {
                _logger.LogInformation("DeleteZone Initiated");
                DeleteZoneCommand deleteZone = new DeleteZoneCommand { ZoneId = id };
                var data = await _mediator.Send(deleteZone);
                _logger.LogInformation("DeleteZone Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("id", Name = "UpdateZone")]
        public async Task<ActionResult> EditZone([FromBody] UpdateZoneCommand model)
        {
            try
            {
                _logger.LogInformation("EditZone Initiated");
                if (string.IsNullOrEmpty(model.ZoneName))
                {
                    return BadRequest("Zone name is required.");
                }

                UpdateZoneCommand updateZoneCommand = new UpdateZoneCommand { };
                var data = await _mediator.Send(model);
                _logger.LogInformation("EditZone Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("id", Name = "GetZoneByEvent")]
        public async Task<ActionResult> GetZoneByEvent(int id)
        {
            try
            {
                _logger.LogInformation("GetZoneEvent Initiated");
                GetZoneByIdCommand getZoneListQuery = new GetZoneByIdCommand() { ZoneId = id };
                var data = await _mediator.Send(getZoneListQuery);
                _logger.LogInformation("GetZoneEvent Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}