using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreatePinCodeCommand;
//using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetStateList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.DeletePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.UpdatePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
//using NeoSoft.A2Zfiling.Application.StateFeatures.DeleteState;
//using NeoSoft.A2Zfiling.Application.StateFeatures.UpdateState;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PinCodeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public PinCodeController(IMediator mediator, ILogger<PinCodeController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllPinCode")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllPinCode()
        {
            _logger.LogInformation("GetAllDocuments Initiated");
            var dtos = await _mediator.Send(new GetPinCodeListQuery());
            _logger.LogInformation("GetAllPinCode Completed");
            return Ok(dtos);
        }
        [HttpGet(Name = "GetPinCodeById")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetPinCodeById(int Id)
        {
            try
            {
                GetPinCodeByIdQuery getByIdPinCodeCommand = new GetPinCodeByIdQuery()
                {
                    PinCodeId = Id
                };
                _logger.LogInformation("GetPinCodeById Initiated");
                var dtos = await _mediator.Send(getByIdPinCodeCommand);
                _logger.LogInformation("GetPinCodeById Completed");
                return Ok(dtos);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }



        [HttpPost(Name = "AddPinCode")]
        public async Task<ActionResult> Create([FromBody] CreatePinCodeCommand createStateCommand)
        {
            var response = await _mediator.Send(createStateCommand);
            return Ok(response);
        }


     

        [HttpPut(Name = "UpdatePinCode")]
        public async Task<ActionResult> Update([FromBody] UpdatePinCodeCommand updatePinCodeCommand)
         {
            _logger.LogInformation("Updating Pincodes Initiated");


            var response = await _mediator.Send(updatePinCodeCommand);
            _logger.LogInformation("Updating Pincodes Initiated");

            return Ok(response);
        }
        [HttpDelete(Name = "DeletePinCode")]
        public async Task<ActionResult> Delete(int Id)
        {
            _logger.LogInformation("Deleting Pincodes Initiated");

            DeletePinCodeCommand deletePinCodeCommand = new DeletePinCodeCommand()
            {
                PinCodeId = Id
            };
            var response = await _mediator.Send(deletePinCodeCommand);
            _logger.LogInformation("Deleting PinCodes Initiated");

            return Ok(response);
        }

    }
}
