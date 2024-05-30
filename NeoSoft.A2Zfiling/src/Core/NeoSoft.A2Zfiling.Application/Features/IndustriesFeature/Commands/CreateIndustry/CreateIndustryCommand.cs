using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateCategory;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry
{
    public class CreateIndustryCommand : IRequest<Response<CreateIndustryDto>>
    {
        public string IndustryName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
