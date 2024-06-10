using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList
{
    public class LicenseListHandler : IRequestHandler<LicenseListCommand, Response<IEnumerable<LicenseListDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<LicenseListHandler> _logger;
        private readonly IAsyncRepository<License> _asyncRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public LicenseListHandler(IAsyncRepository<Category> categoryRepository,IMapper mapper, 
            ILogger<LicenseListHandler> logger, IAsyncRepository<License> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response<IEnumerable<LicenseListDto>>> Handle(LicenseListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var allicense = await _asyncRepository.ListAllAsync();

                var licenseList = allicense.Select(x => new LicenseListDto
                {
                    LicenseId = x.LicenseId,
                    LicenseName = x.LicenseName,
                    ShortName = x.ShortName,
                    IsActive = x.IsActive,
                    CategoryId = x.CategoryId,
                    CategoryName = _categoryRepository.GetByIdAsync(x.CategoryId)?.Result?.CategoryName,
                    ShortList = x.ShortList.ToString(),
                }).ToList();

                //var license = _mapper.Map<IEnumerable<LicenseListDto>>(allicense);
                _logger.LogInformation("Handler Completed");
                return new Response<IEnumerable<LicenseListDto>>(licenseList, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while get all the license ");
                var errorResponse = new Response<IEnumerable<LicenseListDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
