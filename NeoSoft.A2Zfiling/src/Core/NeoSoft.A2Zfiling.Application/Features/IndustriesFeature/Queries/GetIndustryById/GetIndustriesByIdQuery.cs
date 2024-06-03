using MediatR;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById
{
    public class GetIndustriesByIdQuery : IRequest<Response<IndustryListSingleVM>>
    {
        public int IndustryId { get; set; }
    }
}
