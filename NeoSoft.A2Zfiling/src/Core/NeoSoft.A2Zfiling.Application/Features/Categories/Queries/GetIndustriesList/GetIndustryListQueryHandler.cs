using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList
{

    public class GetIndustriesListQueryHandler : IRequestHandler<GetIndustriesListQuery, Response<IEnumerable<IndustryListVM>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<Industry> _industryRepsitory;
        public GetIndustriesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCategoriesListQueryHandler> logger, IAsyncRepository<Industry> industryRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _industryRepsitory = industryRepsitory;
        }

        public async Task<Response<IEnumerable<IndustryListVM>>> Handle(GetIndustriesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allIndustries = (await _industryRepsitory.ListAllAsync()).Where(x => x.IsActive == true).OrderBy(x => x.IndustryName);
            var industry = _mapper.Map<IEnumerable<IndustryListVM>>(allIndustries);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<IndustryListVM>>(industry, "success");
        }

    }



}
