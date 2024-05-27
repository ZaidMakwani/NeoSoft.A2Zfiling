using MediatR;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Response<DeleteCompanyDto>>
    {
        public int CompanyId { get; set; }
    }
}
