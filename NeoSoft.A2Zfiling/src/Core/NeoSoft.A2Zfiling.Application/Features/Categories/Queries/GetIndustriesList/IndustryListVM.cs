using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetIndustriesList
{
    public class IndustryListVM
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
    }
}
