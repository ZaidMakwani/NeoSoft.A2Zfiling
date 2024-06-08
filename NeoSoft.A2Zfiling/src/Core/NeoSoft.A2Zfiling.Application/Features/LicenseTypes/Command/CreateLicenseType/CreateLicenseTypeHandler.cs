using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType
{
    public class CreateLicenseTypeHandler : IRequestHandler<CreateLicenseTypeCommand, Response<CreateLicenseTypeDto>>
    {
        
        private readonly IAsyncRepository<LicenseType> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLicenseTypeHandler> _logger;

        public CreateLicenseTypeHandler(IAsyncRepository<LicenseType> asyncRepository, IMapper mapper, ILogger<CreateLicenseTypeHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;

        }
        public async Task<Response<CreateLicenseTypeDto>> Handle(CreateLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");

                var license = new LicenseType()
                {
                    LicenseName= request.LicenseName,
                    Description = request.Description,
                    IsActive = true,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                };
                var data = await _asyncRepository.AddAsync(license);

                var result = _mapper.Map<CreateLicenseTypeDto>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateLicenseTypeDto>(result, "License Type Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
