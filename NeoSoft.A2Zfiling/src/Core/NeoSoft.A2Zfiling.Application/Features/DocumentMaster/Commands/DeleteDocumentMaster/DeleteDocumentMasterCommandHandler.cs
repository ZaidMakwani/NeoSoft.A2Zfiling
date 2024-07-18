using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.UpdateDocumentMaster;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.DeleteDocumentMaster
{
    public class DeleteDocumentMasterCommandHandler:IRequestHandler<DeleteDocumentMasterCommand,Response<DeleteDocumentMasterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DocumentMasters> _asyncRepository;
        public DeleteDocumentMasterCommandHandler(IMapper mapper, IAsyncRepository<DocumentMasters> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;    
        }

        public async Task<Response<DeleteDocumentMasterDto>> Handle(DeleteDocumentMasterCommand request, CancellationToken cancellationToken)
        {
            var documentId=request.DocumentMasterId;
            var document= await _asyncRepository.GetByIdAsync(documentId);
            document.IsActive = false;
            document.LastModifiedDate = DateTime.Now;
            _mapper.Map(request, document);
            await _asyncRepository.UpdateAsync(document);
            var updateDocument = _mapper.Map<DeleteDocumentMasterDto>(document);
            return new Response<DeleteDocumentMasterDto>(updateDocument, "Document Master deleted successfully");
        }
    }
}
