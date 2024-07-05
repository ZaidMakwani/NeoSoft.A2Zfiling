using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.AboutUs.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.FAQFeatures.Query.GetAll
{
    public class GetAllFAQHandler : IRequestHandler<GetAllFAQQuery, Response<GetFAQDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllFAQHandler> _logger;
        private readonly IAsyncRepository<FAQ> _faqRepository;

        public GetAllFAQHandler(IMapper mapper, ILogger<GetAllFAQHandler> logger, IAsyncRepository<FAQ> faqRepository)
        {
            _faqRepository = faqRepository;
            _mapper = mapper;
            _logger = logger;
        }

        //public async Task<Response<GetFAQDto>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");
        //    var serviceRequest = (await _faqRepository.ListAllAsync());

        //    var serviceRe = _mapper.Map<GetFAQDto>(serviceRequest[0]);

        //    _logger.LogInformation("Hanlde Completed");
        //    return new Response<GetFAQDto>(serviceRe, "Data Fetched Successfully");
        //} 

        public async Task<Response<GetFAQDto>> Handle(GetAllFAQQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var serviceRequest = (await _faqRepository.ListAllAsync());

            var serviceRe = _mapper.Map<GetFAQDto>(serviceRequest[0]);

            _logger.LogInformation("Hanlde Completed");
            return new Response<GetFAQDto>(serviceRe, "Data Fetched Successfully");
        }
    }
}
