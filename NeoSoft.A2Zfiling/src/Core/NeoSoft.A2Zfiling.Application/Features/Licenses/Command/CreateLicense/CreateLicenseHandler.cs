using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense
{
    public class CreateLicenseHandler : IRequestHandler<CreateLicenseCommand, Response<CreateLicenseDto>>
    {
        private readonly IAsyncRepository<License> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLicenseHandler> _logger;
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CreateLicenseHandler(IAsyncRepository<License> asyncRepository, IMapper mapper, ILogger<CreateLicenseHandler> logger, IAsyncRepository<Category> categoryRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _categoryRepository = categoryRepository;
        }
        public async Task<Response<CreateLicenseDto>> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");

                if (!Enum.IsDefined(typeof(ShortList), request.ShortList))
                {
                    //throw new ArgumentException("Invalid ShortList value");
                    return new Response<CreateLicenseDto>(null,"Invalid ShortList Value");
                }

                var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
                if (category == null || !category.IsActive)
                {
                    return new Response<CreateLicenseDto>(null, "Category is inactive or not allowed.");
                }

                var license = new License()
                {
                    LicenseName = request.LicenseName,
                    ShortName = request.ShortName,
                    CategoryId=request.CategoryId,
                    ShortList= request.ShortList,
                    IsActive = true,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                };
                var data = await _asyncRepository.AddAsync(license);

                var result = _mapper.Map<CreateLicenseDto>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateLicenseDto>(result, "License  Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating a license ");
                var errorResponse = new Response<CreateLicenseDto>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
