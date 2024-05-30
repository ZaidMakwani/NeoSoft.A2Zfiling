using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries
{
    public class GetCompaniesByIdQuery : IRequest<Response<CompanyListVM>>
    {
        public int CompanyId { get; set; }

    }
}
