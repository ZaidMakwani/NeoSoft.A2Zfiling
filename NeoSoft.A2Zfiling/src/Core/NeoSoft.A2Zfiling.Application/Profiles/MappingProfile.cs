using AutoMapper;

using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;

using NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument;

using NeoSoft.A2Zfiling.Application.Features.Login;

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
            CreateMap<Login, LoginDto>().ReverseMap();






        }
    }
}
