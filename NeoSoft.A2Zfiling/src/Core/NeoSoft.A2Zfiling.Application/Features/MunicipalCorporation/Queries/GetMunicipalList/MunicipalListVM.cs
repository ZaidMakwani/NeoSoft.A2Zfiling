using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList
{
    public class MunicipalListVM
    {
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public bool IsActive { get; set; }
    }
}
