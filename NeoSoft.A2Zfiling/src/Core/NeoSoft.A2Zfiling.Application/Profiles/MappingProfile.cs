using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById;
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
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany;


namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {




            CreateMap<Industry, CreateIndustryDto>().ReverseMap();
            CreateMap<Industry, IndustryListVM>().ReverseMap();
            CreateMap<Industry, IndustryListSingleVM>().ReverseMap();
            CreateMap<Industry, UpdateIndustryDto>().ReverseMap();
            CreateMap<Industry, UpdateIndustryCommand>().ReverseMap();
            CreateMap<Industry, DeleteIndustryDto>().ReverseMap();

            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyListVM>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, DeleteCompanyDto>().ReverseMap();
            

                CreateMap<AppUser, RegisterDTO>();


                CreateMap<Role, CreateRolesDto>();
                CreateMap<Role, RolesDto>();
                CreateMap<Role, RolesListVM>();
                CreateMap<Role, UpdateRolesCommand>().ReverseMap();
                CreateMap<Role, GetRoleDto>();

                CreateMap<MunicipalCorp, CreateMunicipalDto>();
                CreateMap<MunicipalCorp, MunicipalListVM>();
                CreateMap<MunicipalCorp, UpdateMunicipalCommand>().ReverseMap();
                CreateMap<MunicipalCorp, MunicipalDto>();
                CreateMap<MunicipalCorp, GetMunicipalDto>();

            
        }
    }
}
