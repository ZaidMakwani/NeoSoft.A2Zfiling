using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
