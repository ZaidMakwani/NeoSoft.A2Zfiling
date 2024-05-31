using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;

namespace NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument
{
    public class CreateDocumentCommand : IRequest<Response<CreateDocumentDto>>
    {

        public string DocumentName { get; set; }
        public bool IsActive { get; set; }
    }
}
