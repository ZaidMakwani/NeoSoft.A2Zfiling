using AutoMapper;

using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;

using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById;

using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile: Profile
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

            
        }
    }
}
