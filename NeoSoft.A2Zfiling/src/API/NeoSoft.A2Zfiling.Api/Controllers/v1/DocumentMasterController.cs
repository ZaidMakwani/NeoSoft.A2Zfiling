
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.CreateDocumentMaster;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.DeleteDocumentMaster;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.UpdateDocumentMaster;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetAllDocumentMasterQuery;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetDocumentMaster;
using NeoSoft.A2Zfiling.Persistence.Repositories;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class DocumentMasterController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ILogger<DocumentMasterController> _logger;
        public DocumentMasterController(IMediator mediator, ILogger<DocumentMasterController> logger) {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromForm] CreateDocumentMasterCommand createDocumentMasterCommand)
        {
            var response = await _mediator.Send(createDocumentMasterCommand);
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response=await _mediator.Send(new GetAllDocumentMasterQuery());
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var getDocumentbyId= new GetDocumentMasterByIdQuery() { DocumentMasterId = id };
            var response = await _mediator.Send(getDocumentbyId);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromForm]UpdateDocumentMasterCommand updateDocumentMasterCommand)
        {
            var response = await _mediator.Send(updateDocumentMasterCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult> Delete(int id)
        {
            var getDocumentbyId=new DeleteDocumentMasterCommand() { DocumentMasterId = id };
            var response = await _mediator.Send(getDocumentbyId);
            return Ok(response);

        }

    }
}
