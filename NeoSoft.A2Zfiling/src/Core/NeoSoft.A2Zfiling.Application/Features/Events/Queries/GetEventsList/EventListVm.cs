using System;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public string EventId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
