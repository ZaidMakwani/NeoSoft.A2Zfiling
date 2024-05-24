using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery: IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
