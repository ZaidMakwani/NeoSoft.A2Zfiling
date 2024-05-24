using NeoSoft.A2Zfiling.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
