using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Response<CreateCompanyDto>>
    {
        public string CompanyName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
