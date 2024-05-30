using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoriesList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustriesList
{
    public class GetIndustriesListQuery : IRequest<Response<IEnumerable<IndustryListVM>>>
    {
    }
}
