using NeoSoft.A2Zfiling.Domain.Entities;
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
        public virtual State State { get; set; }

        public int ZoneId { get; set; }
        public virtual Zones Zones { get; set; }

        public virtual City Cities { get; set; }

        public int StateId { get; set; }
        public bool IsActive { get; set; }
    }
}