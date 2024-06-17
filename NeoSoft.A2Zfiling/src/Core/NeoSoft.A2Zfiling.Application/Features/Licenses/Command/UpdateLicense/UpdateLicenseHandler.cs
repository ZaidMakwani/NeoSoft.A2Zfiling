using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense
{
    public class UpdateLicenseHandler : IRequestHandler<UpdateLicenseCommand, Response<UpdateLicenseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<License> _asyncRepository;
        private readonly ILogger<UpdateLicenseHandler> _logger;

        public UpdateLicenseHandler(IMapper mapper, IAsyncRepository<License> asyncRepository, ILogger<UpdateLicenseHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateLicenseDto>> Handle(UpdateLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateLicense Handler Initiated");

                var permissionToUpdate = await _asyncRepository.GetByIdAsync(request.LicenseId);
                if (permissionToUpdate == null)
                {
                    return new Response<UpdateLicenseDto>("License not found");
                }
                _mapper.Map(request, permissionToUpdate);
                await _asyncRepository.UpdateAsync(permissionToUpdate);

                var permission = _mapper.Map<UpdateLicenseDto>(permissionToUpdate);

                _logger.LogInformation("UpdateLicense Handler Completed");
                return new Response<UpdateLicenseDto>(permission, "License Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdateLicenseDto>(null, $"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}
