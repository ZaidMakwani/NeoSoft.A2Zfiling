using MediatR;

using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry
{
    public class UpdateIndustryCommand : IRequest<Response<UpdateIndustryDto>>
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }

    }
}
