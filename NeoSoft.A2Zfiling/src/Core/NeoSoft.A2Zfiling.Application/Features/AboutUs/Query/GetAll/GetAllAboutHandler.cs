using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.TermsAndCondition.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Query.GetAll;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.AboutUs.Query.GetAll
{
    public class GetAllAboutHandler : IRequestHandler<GetAllAboutQuery,Response<GetAboutDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllAboutHandler> _logger;
        private readonly IAsyncRepository<AboutUsDetail> _aboutUsDetailRepository;

        public GetAllAboutHandler(IMapper mapper, ILogger<GetAllAboutHandler> logger, IAsyncRepository<AboutUsDetail> aboutUsDetailRepository)
        {
            _aboutUsDetailRepository = aboutUsDetailRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<GetAboutDto>> Handle(GetAllAboutQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var serviceRequest = (await _aboutUsDetailRepository.ListAllAsync());

            var serviceRe = _mapper.Map<GetAboutDto>(serviceRequest[0]);

            _logger.LogInformation("Hanlde Completed");
            return new Response<GetAboutDto>(serviceRe, "Data Fetched Successfully");
        }
    }
}
