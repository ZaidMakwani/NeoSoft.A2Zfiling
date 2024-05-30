using MediatR;
//using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries
{
    public class GetCompaniesListQuery : IRequest<Response<IEnumerable<CompanyListVM>>>
    {

    }
}
