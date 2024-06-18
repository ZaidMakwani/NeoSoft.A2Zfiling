using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Queries.GetAllLicense
{
     public class GetAllLicenseMasterQueryHandler: IRequestHandler<GetAllLicenseMasterQuery, Response<IEnumerable<GetAllLicenseMasterVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LicenseMaster> _licenseMasterRepository;
        public GetAllLicenseMasterQueryHandler(IAsyncRepository<LicenseMaster> licenseMasterRepository, IMapper mapper) 
        {
            _licenseMasterRepository = licenseMasterRepository;
            _mapper=mapper;
        }
        public async Task<Response<IEnumerable<GetAllLicenseMasterVM>>> Handle(GetAllLicenseMasterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allLicense = (await _licenseMasterRepository.ListAllAsync("LicenseType","License"));
                var license = _mapper.Map<IEnumerable<GetAllLicenseMasterVM>>(allLicense);
                return new Response<IEnumerable<GetAllLicenseMasterVM>>(license, "success");
            }
            catch (Exception ex)
            {
                var error= new Response<IEnumerable<GetAllLicenseMasterVM>>(null,ex.Message);
                return error;
            }
        }
    }   
}
