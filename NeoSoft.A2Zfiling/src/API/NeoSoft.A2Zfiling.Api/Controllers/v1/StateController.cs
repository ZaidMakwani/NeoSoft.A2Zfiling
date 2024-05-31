using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.DeleteState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public StateController(IMediator mediator, ILogger<StateController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllStates")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllStates()
        {
            _logger.LogInformation("GetAllStates Initiated");
            var dtos = await _mediator.Send(new GetStateListQuery());
            _logger.LogInformation("GetAllSates Completed");
            return Ok(dtos);
        }



        [HttpGet(Name = "GetStateById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetStateById(int Id)
        {
            try
            {
                GetStateByIdQuery getIdStateByCommand = new GetStateByIdQuery()
                {
                    StateId = Id
                };
                _logger.LogInformation("GetStateById Initiated");
                var dtos = await _mediator.Send(getIdStateByCommand);
                _logger.LogInformation("GetStateById Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }










        [HttpPost(Name = "AddState")]
        public async Task<ActionResult> Create([FromBody] CreateStateCommand createStateCommand)
        {
            var response = await _mediator.Send(createStateCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateState")]
        public async Task<ActionResult> Update([FromBody] UpdateStateCommand updateStateCommand)
        {


            _logger.LogInformation("Updating States Initiated");

            var response = await _mediator.Send(updateStateCommand);
            _logger.LogInformation("Updating States Initiated");

            return Ok(response);
        }


        [HttpDelete(Name = "DeleteState")]
        public async Task<ActionResult> Delete(int Id)
        {
            DeleteStateCommand deleteStateCommand = new DeleteStateCommand()
            {
                StateId = Id
            };
            var response = await _mediator.Send(deleteStateCommand);
            return Ok(response);
        }

       

    }
}
