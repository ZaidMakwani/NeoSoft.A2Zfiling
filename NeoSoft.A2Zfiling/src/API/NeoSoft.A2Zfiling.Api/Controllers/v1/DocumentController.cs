using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument;

namespace NeoSoft.A2Zfiling.Api.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public DocumentController(IMediator mediator, ILogger<DocumentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        //[Authorize]
        [HttpGet("all", Name = "GetAllDocuments")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> GetAllDocuments()
        //{
        //    _logger.LogInformation("GetAllDocuments Initiated");
        //    var dtos = await _mediator.Send(new GetDocumentsListQuery());
        //    _logger.LogInformation("GetAllDocuments Completed");
        //    return Ok(dtos);
        //}

        //[Authorize]
        //[HttpGet("allwithevents", Name = "GetDocumentsWithEvents")]
        //[ProducesDefaultResponseType]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> GetDocumentsWithEvents(bool includeHistory)
        //{
        //    GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery() { IncludeHistory = includeHistory };

        //    var dtos = await _mediator.Send(getCategoriesListWithEventsQuery);
        //    return Ok(dtos);
        //}

        [HttpPost(Name = "AddDocument")]
        public async Task<ActionResult> Create([FromBody] CreateDocumentCommand createDocumentCommand)
        {
            var response = await _mediator.Send(createDocumentCommand);
            return Ok(response);
        }

        
    }
}
