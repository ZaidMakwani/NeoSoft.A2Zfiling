using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid
{
    public class LicenseListByIdHandler : IRequestHandler<LicenseListByIdCommand, Response<LicenseListByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<LicenseListByIdHandler> _logger;
        private readonly IAsyncRepository<License> _asyncRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public LicenseListByIdHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper,
            ILogger<LicenseListByIdHandler> logger, IAsyncRepository<License> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<LicenseListByIdDto>> Handle(LicenseListByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetLicenseById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.LicenseId);
                if (getById == null)
                {
                    return new Response<LicenseListByIdDto>(" License not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<LicenseListByIdDto>("License is not active");
                }
                var categoryName = await _categoryRepository.GetByIdAsync(getById.CategoryId);
                if (categoryName == null)
                {
                    return new Response<LicenseListByIdDto>("Category not found");
                }

                var data = _mapper.Map<LicenseListByIdDto>(getById);
                data.CategoryName = categoryName.CategoryName;

                _logger.LogInformation("GetLicenseById Completed");
                return new Response<LicenseListByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<LicenseListByIdDto>(null, $"Error : {ex.Message}");
                return errorMessage;
            }
        }
    }
}
