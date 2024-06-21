using NeoSoft.A2Zfiling.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList
{
    public class GetCityListDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }
        public int StateId { get; set; }
        public string StateName { get; set; }   
        [JsonIgnore]
        public virtual State State { get; set; }

        public int ZoneId { get; set; }
        public string ZoneName { get; set; }    
        [JsonIgnore]
        public virtual Zones Zones { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; }

       
        public bool IsActive { get; set; }
    }
}