using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.CreateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.Transaction;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.UpdateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventDetail;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.Orders.GetOrdersForMonth;
using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {          
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, TransactionCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, StoredProcedureCommand>().ReverseMap();
            CreateMap<Category, StoredProcedureDto>().ReverseMap();

            CreateMap<Order, OrdersForMonthDto>().ReverseMap();
            CreateMap<Industry, CreateIndustryDto>().ReverseMap();
            CreateMap<Industry, IndustryListVM>().ReverseMap();
            CreateMap<Industry, UpdateIndustryDto>().ReverseMap();
            CreateMap<Industry, UpdateIndustryCommand>().ReverseMap();
            CreateMap<Industry, DeleteIndustryDto>().ReverseMap();

            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyListVM>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, DeleteCompanyDto>().ReverseMap();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
