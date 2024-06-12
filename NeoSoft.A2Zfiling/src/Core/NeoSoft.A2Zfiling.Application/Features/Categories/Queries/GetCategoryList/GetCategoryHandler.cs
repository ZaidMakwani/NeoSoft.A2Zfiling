using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryCommand, Response<IEnumerable<GetCategoryListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryHandler> _logger;
        private readonly IAsyncRepository<Category> _asyncRepository;

        public GetCategoryHandler(IMapper mapper, ILogger<GetCategoryHandler> logger, IAsyncRepository<Category> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<GetCategoryListDto>>> Handle(GetCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var allCategory = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive == true);

                var category = _mapper.Map<IEnumerable<GetCategoryListDto>>(allCategory);
                _logger.LogInformation("Handler Completed");
                return new Response<IEnumerable<GetCategoryListDto>>(category, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
