using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.CreateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.Transaction;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.UpdateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventDetail;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Features.Orders.GetOrdersForMonth;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleaDetails;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
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

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, StoredProcedureCommand>();
            CreateMap<Category, StoredProcedureDto>();

            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();

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
