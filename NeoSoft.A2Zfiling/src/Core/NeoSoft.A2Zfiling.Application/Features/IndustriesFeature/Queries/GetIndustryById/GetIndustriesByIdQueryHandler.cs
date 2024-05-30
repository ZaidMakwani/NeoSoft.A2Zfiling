using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById
{
    public class GetIndustriesByIdQueryHandler : IRequestHandler<GetIndustriesByIdQuery, Response<IndustryListSingleVM>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<Industry> _industryRepsitory;
        public GetIndustriesByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCompaniesListQueryHandler> logger, IAsyncRepository<Industry> industryRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<IndustryListSingleVM>> Handle(GetIndustriesByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handle Initiated");
                var industry = await _industryRepsitory.GetByIdAsync(request.IndustryId);
                var industryVM = _mapper.Map<IndustryListSingleVM>(industry);
                _logger.LogInformation("Hanlde Completed");
                return new Response<IndustryListSingleVM>(industryVM, "success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
