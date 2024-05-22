using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using System;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
