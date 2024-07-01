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

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetAllDocumentMasterQuery
{
    public class GetAllDocumentMasterQueryHandler : IRequestHandler<GetAllDocumentMasterQuery, Response<IEnumerable<GetAllDocumentMasterQueryVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<DocumentMasters> _asyncRepository;

        public GetAllDocumentMasterQueryHandler(IMapper mapper, IAsyncRepository<DocumentMasters> asyncRepository)
        {
            _mapper=mapper;
            _asyncRepository=asyncRepository;
        }
        public async Task<Response<IEnumerable<GetAllDocumentMasterQueryVM>>> Handle(GetAllDocumentMasterQuery request, CancellationToken cancellationToken)
        {
            var allDocuments = await _asyncRepository.ListAllAsync();
            var documents= _mapper.Map<IEnumerable<GetAllDocumentMasterQueryVM>>(allDocuments);

            return new Response<IEnumerable<GetAllDocumentMasterQueryVM>>(documents,"success");
        }
    }
}
