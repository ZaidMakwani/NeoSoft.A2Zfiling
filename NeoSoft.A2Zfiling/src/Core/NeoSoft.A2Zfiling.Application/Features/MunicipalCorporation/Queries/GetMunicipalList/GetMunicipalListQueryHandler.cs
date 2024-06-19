using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList
{
    public class GetMunicipalListQueryHandler : IRequestHandler<GetMunicipalListQuery, Response<IEnumerable<MunicipalListVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepository;

        public GetMunicipalListQueryHandler(IAsyncRepository<MunicipalCorp> municipalRepository, IMapper mapper)
        {
            _municipalRepository = municipalRepository;
            _mapper = mapper;

        }

        public async Task<Response<IEnumerable<MunicipalListVM>>> Handle(GetMunicipalListQuery request, CancellationToken cancellationToken)
        {

            var allMunicipals = (await _municipalRepository.ListAllAsync("Zones","City","State"));
            var licenseList = allMunicipals.Select(x => new MunicipalListVM
            {
                MunicipalId = x.MunicipalId,
                MunicipalName = x.MunicipalName,
                Pincode = x.Pincode,
                CityId = x.CityId,
                CityName = x.City.CityName,

                IsActive = x.IsActive,
                ZoneId = x.ZoneId,

                StateId = x.StateId,
                StateName = x.State.StateName,
                ZoneName = x.Zones.ZoneName


            }).ToList();
            //var municipals = _mapper.Map<IEnumerable<MunicipalListVM>>(allMunicipals.Where(x => x.IsActive == true));

            return new Response<IEnumerable<MunicipalListVM>>(licenseList, "success");
        }
    }
}
