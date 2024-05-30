using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
//using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries
{

    public class GetCompaniesListQueryHandler : IRequestHandler<GetCompaniesListQuery, Response<IEnumerable<CompanyListVM>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<Company> _companyRepsitory;
        public GetCompaniesListQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCompaniesListQueryHandler> logger, IAsyncRepository<Company> companyRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _companyRepsitory = companyRepsitory;
        }

        public async Task<Response<IEnumerable<CompanyListVM>>> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var allCompanies = (await _companyRepsitory.ListAllAsync()).Where(x => x.IsActive == true).OrderBy(x => x.CompanyName);
            var company = _mapper.Map<IEnumerable<CompanyListVM>>(allCompanies);
            _logger.LogInformation("Hanlde Completed");
            return new Response<IEnumerable<CompanyListVM>>(company, "success");
        }

    }

}
