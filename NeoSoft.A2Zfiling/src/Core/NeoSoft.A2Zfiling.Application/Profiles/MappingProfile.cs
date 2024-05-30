using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleaDetails;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
using NeoSoft.A2Zfiling.Domain.Entities;
using System.Security.Principal;


namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

           CreateMap<AppUser, RegisterDTO>();

          
            CreateMap<Role, CreateRolesDto>();
            CreateMap<Role,RolesDto>();
            CreateMap<Role,RolesListVM>();
            CreateMap<Role,UpdateRolesCommand>().ReverseMap();
            CreateMap<Role, GetRoleDto>();

            CreateMap<MunicipalCorp, CreateMunicipalDto>();
            CreateMap<MunicipalCorp, MunicipalListVM>();
            CreateMap<MunicipalCorp, UpdateMunicipalCommand>().ReverseMap();
            CreateMap<MunicipalCorp, MunicipalDto>();
            CreateMap<MunicipalCorp, GetMunicipalDto>();

        }
    }
}
