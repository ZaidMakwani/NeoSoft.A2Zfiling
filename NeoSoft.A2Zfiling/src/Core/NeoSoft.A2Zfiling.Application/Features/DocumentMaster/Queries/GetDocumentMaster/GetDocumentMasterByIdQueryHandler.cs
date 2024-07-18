using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetAllDocumentMasterQuery;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetDocumentMaster
{
    public class GetDocumentMasterByIdQueryHandler : IRequestHandler<GetDocumentMasterByIdQuery, Response<GetAllDocumentMasterQueryVM>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DocumentMasters> _asyncRepository;
        public GetDocumentMasterByIdQueryHandler(IMapper mapper, IAsyncRepository<DocumentMasters> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetAllDocumentMasterQueryVM>> Handle(GetDocumentMasterByIdQuery request, CancellationToken cancellationToken)
        {
           var documentMasterId=request.DocumentMasterId;
            var documentMaster= await _asyncRepository.GetByIdAsync(documentMasterId);
            if (documentMaster == null)
            {
                return new Response<GetAllDocumentMasterQueryVM>(null, "Not found");
            }
            else
            {
                if (documentMaster.IsActive)
                {
                    var doc = _mapper.Map<GetAllDocumentMasterQueryVM>(documentMaster);
                    return new Response<GetAllDocumentMasterQueryVM>(doc, "success");
                }
                else
                {
                    return new Response<GetAllDocumentMasterQueryVM>() { Message = "InActive/Not Found" };
                }
            }
        }
    }
}
