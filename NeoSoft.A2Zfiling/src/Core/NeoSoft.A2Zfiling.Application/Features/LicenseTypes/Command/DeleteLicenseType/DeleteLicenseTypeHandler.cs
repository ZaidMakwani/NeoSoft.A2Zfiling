using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType
{
    public class DeleteLicenseTypeHandler : IRequestHandler<DeleteLicenseTypeCommand, Response<DeleteLicenseTypeDto>>
    {
        private readonly ILogger<DeleteLicenseTypeDto> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseType> _asyncRepository;

        public DeleteLicenseTypeHandler(ILogger<DeleteLicenseTypeDto> logger, IMapper mapper, IAsyncRepository<LicenseType> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<DeleteLicenseTypeDto>> Handle(DeleteLicenseTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var getById = await _asyncRepository.GetByIdAsync(request.LicenseTypeId);
                if (getById == null)
                {
                    _logger.LogInformation("License Type not found");
                    return new Response<DeleteLicenseTypeDto>("License Type not found.");
                }
                getById.IsActive = false;
                //getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteLicenseDto = _mapper.Map<DeleteLicenseTypeDto>(getById);
                _logger.LogInformation("Handler Completed");
                return new Response<DeleteLicenseTypeDto>(deleteLicenseDto, "License Type Deleted Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
