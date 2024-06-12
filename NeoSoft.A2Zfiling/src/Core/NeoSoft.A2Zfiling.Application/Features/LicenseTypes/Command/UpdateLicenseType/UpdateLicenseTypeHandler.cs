using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType
{
    public class UpdateLicenseTypeHandler : IRequestHandler<UpdateLicenseTypeCommand, Response<UpdateLicenseTypeDto>>
    {
        private readonly ILogger<UpdateLicenseTypeHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseType> _asyncRepository;

        public UpdateLicenseTypeHandler(ILogger<UpdateLicenseTypeHandler> logger, IMapper mapper, IAsyncRepository<LicenseType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<UpdateLicenseTypeDto>> Handle(UpdateLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = await _asyncRepository.GetByIdAsync(request.LicenseTypeId);
                if (getById == null)
                {
                    return new Response<UpdateLicenseTypeDto>("License Type not found.");
                }
                _mapper.Map(request, getById);
                await _asyncRepository.UpdateAsync(getById);
                var data = _mapper.Map<UpdateLicenseTypeDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<UpdateLicenseTypeDto>(data, "License Type Updated Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
