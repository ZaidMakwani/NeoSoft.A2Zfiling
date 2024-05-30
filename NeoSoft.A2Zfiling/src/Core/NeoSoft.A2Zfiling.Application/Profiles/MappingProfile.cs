using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById;
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
            CreateMap<Zones, CreateZoneDto>().ReverseMap();
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
            CreateMap<City, GetCityByIdDto>().ReverseMap();
            CreateMap<City,GetCityByIdCommand>().ReverseMap();

            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermisssionCommand>().ReverseMap();
            CreateMap<Permission,GetPermissionListDto>().ReverseMap();
            CreateMap<Permission, GetPermissionByIdDto>().ReverseMap();
            CreateMap<Permission,UpdatePermissionCommand>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();
            CreateMap<Permission,DeletePermissionDto>().ReverseMap();


            CreateMap<UserPermission,CreateUserPermissionDto>().ReverseMap();
            CreateMap<UserPermission,GetUserPermissionDto>().ReverseMap();
            CreateMap<UserPermission, GetUserPermissionByIdDto>().ReverseMap();
            CreateMap<UserPermission,GetUserPermissionCommand>().ReverseMap();
            CreateMap<UserPermission,DeleteUserPermissionDto>().ReverseMap();
            CreateMap<UserPermission, UpdateUserPermissionCommand>().ReverseMap();
            CreateMap<UserPermission,UpdateUserPermissionDto>().ReverseMap();
        }
    }
}
