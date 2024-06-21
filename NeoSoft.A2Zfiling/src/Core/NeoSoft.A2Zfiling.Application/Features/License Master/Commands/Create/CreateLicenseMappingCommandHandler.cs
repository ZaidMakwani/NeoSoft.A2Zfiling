using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Create
{
    public class CreateLicenseMappingCommandHandler:IRequestHandler<CreateLicenseMappingCommand, Response<CreateLicenceMappingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseMaster> _aysncRepository;
        private readonly IMessageRepository _messageRepository;
        public CreateLicenseMappingCommandHandler(IAsyncRepository<LicenseMaster> aysncRepository, IMapper mapper)
        {
            _aysncRepository = aysncRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateLicenceMappingDto>> Handle(CreateLicenseMappingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Response<CreateLicenceMappingDto> licenseresponse = null;
                var license = new LicenseMaster()
                {
                   // LicenseName = request.LicenseName,
                    //Classification = request.Classification,
                    LicenseId = request.LicenseId,
                    LicenseTypeId= request.LicenseTypeId,
                    Validity = request.Validity,
                    Visibilities = request.Visibilities,
                    ZoneId = request.ZoneId,
                    StateId = request.StateId,
                    CityId = request.CityId,
                    MunicipalId = request.MunicipalId,
                    IndustryId = request.IndustryId,
                    CompanyId = request.CompanyId,
                    StandardRate = request.StandardRate,
                    StandardTAT = request.StandardTAT,
                    FastTrackRate = request.FastTrackRate,
                    FastTrackTAT = request.FastTrackTAT,
                    CreatedDate = DateTime.Now,
                    IsActive=true
                };
                license = await _aysncRepository.AddAsync(license);
                licenseresponse = new Response<CreateLicenceMappingDto>(_mapper.Map<CreateLicenceMappingDto>(license), "success");

                return licenseresponse;
            } 
            catch (Exception ex)
            {
                var error = new Response<CreateLicenceMappingDto>(null, ex.Message);
                return error;
            }
        }
    }
}
