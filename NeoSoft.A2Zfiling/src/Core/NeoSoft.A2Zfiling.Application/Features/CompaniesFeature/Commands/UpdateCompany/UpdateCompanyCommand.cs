using MediatR;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Response<UpdateCompanyDto>>
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
