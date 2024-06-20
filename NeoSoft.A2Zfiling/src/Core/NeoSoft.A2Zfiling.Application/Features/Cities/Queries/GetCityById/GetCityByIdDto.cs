using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById
{
    public class GetCityByIdDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }


        public bool IsActive { get; set; }
        public int StateId { get; set; }
        public int ZoneId { get; set; }

    }
}
