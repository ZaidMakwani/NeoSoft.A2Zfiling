using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.UpdateDocumentMaster
{
   
    public class UpdateDocumentMasterCommandHandler:IRequestHandler<UpdateDocumentMasterCommand,Response<UpdateDocumentMasterCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DocumentMasters> _asyncRepository;

        public UpdateDocumentMasterCommandHandler(IMapper mapper, IAsyncRepository<DocumentMasters> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<UpdateDocumentMasterCommandDto>> Handle(UpdateDocumentMasterCommand request, CancellationToken cancellationToken)
        {
            var document=await _asyncRepository.GetByIdAsync(request.DocumentMasterId);
            if (document == null )
            {
                return new Response<UpdateDocumentMasterCommandDto>(null, "Not Found");
            }
            else
            {
                    var documentObj = new DocumentMasters()
                    {
                        DocumentName = request.DocumentName,
                        DocumentFormat = String.Join(",", request.DocumentFormat),
                        SampleFormat = request.SampleFormat,
                        IsActive = request.IsActive,
                        LastModifiedDate = DateTime.Now,
                    };

                    _mapper.Map(request, documentObj);
                    document.IsActive = request.IsActive;
                    document.DocumentName = request.DocumentName;
                    document.LastModifiedDate = DateTime.Now;
                    document.SampleFormat = request.SampleFormat;
                    document.DocumentFormat = string.Join(",", request.DocumentFormat);
                    await _asyncRepository.UpdateAsync(document);
                    var updateDocument = _mapper.Map<UpdateDocumentMasterCommandDto>(document);
                    return new Response<UpdateDocumentMasterCommandDto>(updateDocument, "Document Master updated successfully");
                }
            
        }
    }
}
