
﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityByState;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent;
namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CityController> _logger;

        public CityController(IMediator mediator, ILogger<CityController> logger)
        {
            _logger = logger;
            _mediator = mediator;

        }
        [HttpGet("all", Name = "GetAllCity")]
        public async Task<ActionResult> GetAllCity()
        {
            try
            {
                _logger.LogInformation("GetAllCity Initiated");
                var data = await _mediator.Send(new GetCityListCommand());
                _logger.LogInformation("GetAllCity Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetAllCityByState(int StateId)
        {
            try
            {
                _logger.LogInformation("GetAllCityByState Initiated");
                var data = await _mediator.Send(new GetAllCityByStateQuery() { StateId=StateId});
                _logger.LogInformation("GetAllCityByState Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost(Name = "AddCity")]
        public async Task<ActionResult> CreateCity([FromBody] CreateCityCommand model)
        {
            try
            {
                _logger.LogInformation("AddCity Initiated");
                var data = await _mediator.Send(model);
                _logger.LogInformation("AddCity Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("id", Name = "UpdataCity")]
        public async Task<ActionResult> EditCity([FromBody] UpdateCityCommand model)
        {
            try
            {
                _logger.LogInformation("UpdateCity Initiated");
                if (string.IsNullOrEmpty(model.CityName))
                {
                    return BadRequest("City name is required.");
                }
                UpdateCityCommand updateCityCommand = new UpdateCityCommand { };
                var data = await _mediator.Send(model);
                _logger.LogInformation("UpdateCity Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("id", Name = "DeleteCity")]
        public async Task<ActionResult> DeleteCity(int id)
        {
            try
            {
                _logger.LogInformation("DeleteCity Initiated");
                DeleteCityCommand deleteCity = new DeleteCityCommand { CityId = id };
                var data = await _mediator.Send(deleteCity);
                _logger.LogInformation("DeleteCity Completed");
                return Ok(data);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("id", Name = "GetCityById")]
        public async Task<ActionResult> GetCityById(int id)
        {
            try
            {
                _logger.LogInformation("GetCityById Initiated");
                GetCityByIdCommand getCityById = new GetCityByIdCommand() { CityId = id };
                var data = await _mediator.Send(getCityById);
                _logger.LogInformation("GetCityById Completed");
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}