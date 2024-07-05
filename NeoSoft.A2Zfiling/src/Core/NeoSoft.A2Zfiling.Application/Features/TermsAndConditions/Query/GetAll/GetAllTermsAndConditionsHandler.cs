using AutoMapper;

using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Query.GetAll;


namespace NeoSoft.A2Zfiling.Application.Features.TermsAndCondition.Query.GetAll
{
    public class GetAllTermsAndConditionsHandler: IRequestHandler<GetAllTermsAndConditionsQuery, Response<GetAllTermsAndConditionsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllTermsAndConditionsHandler> _logger;
        private readonly IAsyncRepository<TermsAndConditionsss> _termsAndConditionsRepository;

        public GetAllTermsAndConditionsHandler(IMapper mapper, ILogger<GetAllTermsAndConditionsHandler> logger, IAsyncRepository<TermsAndConditionsss> termsAndConditiontRepository)
        {
            _termsAndConditionsRepository = termsAndConditiontRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<GetAllTermsAndConditionsDto>> Handle(GetAllTermsAndConditionsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var serviceRequest = (await _termsAndConditionsRepository.ListAllAsync());

            var serviceRe = _mapper.Map<GetAllTermsAndConditionsDto>(serviceRequest[0]);

            _logger.LogInformation("Hanlde Completed");
            return new Response<GetAllTermsAndConditionsDto>(serviceRe, "Data Fetched Successfully");
        }


    }
}
