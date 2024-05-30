using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries
{

    public class GetCompaniesByIdQueryHandler :  IRequestHandler<GetCompaniesByIdQuery, Response<CompanyListVM>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IAsyncRepository<Company> _companyRepsitory;
        public GetCompaniesByIdQueryHandler(IMapper mapper, ICategoryRepository categoryRepository, ILogger<GetCompaniesListQueryHandler> logger, IAsyncRepository<Company> companyRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _logger = logger;
            _companyRepsitory = companyRepsitory;
        }

        public async Task<Response<CompanyListVM>> Handle(GetCompaniesByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var company = (await _companyRepsitory.GetByIdAsync(request.CompanyId));
            var companyVM = _mapper.Map<CompanyListVM>(company);
            _logger.LogInformation("Hanlde Completed");
            return new Response<CompanyListVM>(companyVM, "success");
        }

    }
}
