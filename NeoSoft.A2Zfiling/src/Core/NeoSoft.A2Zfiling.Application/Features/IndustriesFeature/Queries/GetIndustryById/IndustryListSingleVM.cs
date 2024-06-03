using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById
{
    public class IndustryListSingleVM
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
