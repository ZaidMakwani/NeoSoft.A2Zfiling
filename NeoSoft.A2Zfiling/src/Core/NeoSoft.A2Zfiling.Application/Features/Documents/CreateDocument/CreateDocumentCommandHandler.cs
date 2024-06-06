using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Exceptions;
using System.Reflection.Metadata;
using Document = NeoSoft.A2Zfiling.Domain.Entities.Document;


namespace NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument
{
    public class CreateStateCommandHandler : IRequestHandler<CreateDocumentCommand, Response<CreateDocumentDto>>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<Document> _industryRepsitory;

        public CreateStateCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<Document> industryRepsitory)
        {
            _mapper = mapper;
            
            _messageRepository = messageRepository;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<CreateDocumentDto>> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            Response<CreateDocumentDto> createDocumentCommandResponse = null;

            var validator = new CreateDocumentCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var document = new Document() { DocumentName = request.DocumentName };
                document = await _industryRepsitory.AddAsync(document);
                createDocumentCommandResponse = new Response<CreateDocumentDto>(_mapper.Map<CreateDocumentDto>(document), "success");
            }

            return createDocumentCommandResponse;
        }
    }
}
