using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.CreateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent;
using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Zones, CreateZoneCommand>().ReverseMap();
            CreateMap<Zones, GetZoneListDto>().ReverseMap();
            CreateMap<Zones, DeleteZoneDto>().ReverseMap();
            CreateMap<Zones, UpdateZoneDto>().ReverseMap();
            CreateMap<Zones, UpdateZoneCommand>().ReverseMap();
            CreateMap<Zones, GetEventByIdDto>().ReverseMap();
            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, GetCityListDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();
            CreateMap<City, DeleteCityDto>().ReverseMap();
        }
    }
}
