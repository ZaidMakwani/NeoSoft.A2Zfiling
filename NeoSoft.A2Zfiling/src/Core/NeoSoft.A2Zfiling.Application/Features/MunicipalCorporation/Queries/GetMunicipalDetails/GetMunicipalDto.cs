using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails
{
    public class GetMunicipalDto
    {
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public bool IsActive { get; set; }
        public int CityId { get; set; }
        public int ZoneId { get; set; }
        public int StateId { get; set; }
        public string? Pincode { get; set; }

    }
}
