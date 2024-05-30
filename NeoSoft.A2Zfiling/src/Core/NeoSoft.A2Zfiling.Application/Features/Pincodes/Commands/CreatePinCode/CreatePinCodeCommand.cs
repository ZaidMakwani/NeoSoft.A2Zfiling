using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateDocument;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreatePinCodeCommand
{
    public class CreatePinCodeCommand : IRequest<Response<CreatePinCodeDto>>
    {

        public int PinCodeId { get; set; }
        public long PinCodeNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
