using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal
{
   public class CreateMunicipalDto
    {
        public string MunicipalName { get; set; }
        public bool IsActive { get; set; }
        public string PinCode { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }

    }
}
