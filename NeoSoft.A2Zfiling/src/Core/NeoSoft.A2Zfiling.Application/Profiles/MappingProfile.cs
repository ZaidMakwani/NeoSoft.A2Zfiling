using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateDocument;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.StoredProcedure;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.CreateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.Transaction;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.UpdateEvent;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventDetail;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsExport;
using NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList;
using NeoSoft.A2Zfiling.Application.Features.Orders.GetOrdersForMonth;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.DeletePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.UpdatePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.DeleteState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
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
            CreateMap<Document, CreateDocumentDto>().ReverseMap();

            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, StateListVm>().ReverseMap();
            CreateMap<State, DeleteStateDto>().ReverseMap();

            CreateMap<State, UpdateStateDto>().ReverseMap();
            CreateMap<State, UpdateStateCommand>().ReverseMap();
            CreateMap<State, StateVM>().ReverseMap();



            CreateMap<PinCode, CreatePinCodeDto>().ReverseMap();
            CreateMap<PinCode, PinCodeListVm>().ReverseMap();
            CreateMap<PinCode, DeletePinCodeDto>().ReverseMap();
            CreateMap<PinCode, UpdatePinCodeDto>().ReverseMap();
            CreateMap<PinCode, UpdatePinCodeCommand>().ReverseMap();
            CreateMap<PinCode, PinCodeVM>().ReverseMap();






            CreateMap<Order, OrdersForMonthDto>();

            CreateMap<Event, EventListVm>().ConvertUsing<EventVmCustomMapper>();
        }
    }
}
