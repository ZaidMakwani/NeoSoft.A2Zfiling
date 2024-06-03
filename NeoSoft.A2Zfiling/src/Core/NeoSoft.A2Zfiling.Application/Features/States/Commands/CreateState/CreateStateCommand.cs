using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;


namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState
{
    public class CreateStateCommand : IRequest<Response<CreateStateDto>>
    {

        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
