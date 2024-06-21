using NeoSoft.A2Zfiling.Domain.Entities;
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
        public string Pincode {  get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }
       // public string PinCode { get; set; }
       
        public virtual City City { get; set; }

        public string CityName { get; set; }
        public string StateName { get; set; }
        public string ZoneName { get; set; }
        public int ZoneId { get; set; }
        public virtual Zones Zones { get; set; }
       
        public virtual State State { get; set; }
    }
}
