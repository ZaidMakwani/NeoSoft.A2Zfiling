using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense
{
    public class DeleteLicenseHandler : IRequestHandler<DeleteLicenseCommand, Response<DeleteLicenseDto>>
    {

        private readonly IMapper _mapper;
        private readonly ILogger<DeleteLicenseHandler> _logger;
        private readonly IAsyncRepository<License> _asyncRepository;

        public DeleteLicenseHandler(IMapper mapper, ILogger<DeleteLicenseHandler> logger, IAsyncRepository<License> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<DeleteLicenseDto>> Handle(DeleteLicenseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeleteLicense Handler Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.LicenseId);
                if (getById == null)
                {
                    return new Response<DeleteLicenseDto>("License not found");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeleteLicenseDto>(getById);
                _logger.LogInformation("DeleteLicense Handler Completed");
                return new Response<DeleteLicenseDto>(deleteData, "License Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeleteLicenseDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}
