using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Create;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Edit
{
    public class UpdateLicenseMasterCommandHandler : IRequestHandler<UpdateLicenseMasterCommand, Response<CreateLicenceMappingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseMaster> _aysncRepository;
        private readonly IMessageRepository _messageRepository;
        public UpdateLicenseMasterCommandHandler(IAsyncRepository<LicenseMaster> aysncRepository, IMapper mapper)
        {
            _aysncRepository = aysncRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateLicenceMappingDto>> Handle(UpdateLicenseMasterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var licensetoUpdate = await _aysncRepository.GetByIdAsync(request.LicenceMasterId);
                if (licensetoUpdate == null)
                {

                    throw new NotFoundException("Not Found", request.LicenceMasterId);
                }

                _mapper.Map(request, licensetoUpdate);
                licensetoUpdate.LastModifiedDate = DateTime.Now;

                await _aysncRepository.UpdateAsync(licensetoUpdate);
                var updateLicense = _mapper.Map<CreateLicenceMappingDto>(licensetoUpdate);

                return new Response<CreateLicenceMappingDto>(updateLicense, "License Master Updated Successfully");
            }
            catch (Exception ex)
            {
                var error = new Response<CreateLicenceMappingDto>(null, ex.Message);
                return error;
            }
        }
    }
}
