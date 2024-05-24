using MediatR;
using System;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest
    {
        public string EventId { get; set; }
    }
}
