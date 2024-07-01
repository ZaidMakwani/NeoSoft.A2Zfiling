using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.CreateDocumentMaster
{
    public class CreateDocumentMasterCommandHandler : IRequestHandler<CreateDocumentMasterCommand, Response<CreateDocumentMasterCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DocumentMasters> _asyncRepository;
        private readonly ILogger<CreateDocumentMasterCommandHandler> _logger;
        public CreateDocumentMasterCommandHandler(ILogger<CreateDocumentMasterCommandHandler> logger, IAsyncRepository<DocumentMasters> asyncRepository, IMapper mapper) {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<CreateDocumentMasterCommandDto>> Handle(CreateDocumentMasterCommand request, CancellationToken cancellationToken)
        {
            Response<CreateDocumentMasterCommandDto> documentResponse = null;
            
          
                //_logger.LogInformation($"File '{uploadFile.FileName}' uploaded and saved to '{filePath}' on the file system.");

                var document = new DocumentMasters()
                {
                    DocumentName = request.DocumentName,
                    DocumentFormat = request.DocumentFormat,
                    SampleFormat = request.SampleFormat,
                    IsActive = request.IsActive,
                    CreatedDate = DateTime.Now
                };
                document = await _asyncRepository.AddAsync(document);
                documentResponse = new Response<CreateDocumentMasterCommandDto>(_mapper.Map<CreateDocumentMasterCommandDto>(document), "success");

            
            return documentResponse;
        }
    }
}
