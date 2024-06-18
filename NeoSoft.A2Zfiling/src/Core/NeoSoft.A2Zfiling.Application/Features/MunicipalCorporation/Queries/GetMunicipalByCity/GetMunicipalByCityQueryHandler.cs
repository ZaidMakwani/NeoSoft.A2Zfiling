using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalByCity
{
    public class GetMunicipalByCityQueryHandler:IRequestHandler<GetMunicipalByCityQuery, Response<IEnumerable<MunicipalListVM>>>
    {
        private readonly IMapper _mapper;
    private readonly IAsyncRepository<MunicipalCorp> _municipalRepository;

    public GetMunicipalByCityQueryHandler(IAsyncRepository<MunicipalCorp> municipalRepository, IMapper mapper)
    {
        _municipalRepository = municipalRepository;
        _mapper = mapper;

    }

    public async Task<Response<IEnumerable<MunicipalListVM>>> Handle(GetMunicipalByCityQuery request, CancellationToken cancellationToken)
    {

        var allMunicipals = (await _municipalRepository.ListAllAsync());
        var municipals = _mapper.Map<IEnumerable<MunicipalListVM>>(allMunicipals.Where(x => x.IsActive == true && x.CityId==request.CityId));

        return new Response<IEnumerable<MunicipalListVM>>(municipals, "success");
    }
}

    }

