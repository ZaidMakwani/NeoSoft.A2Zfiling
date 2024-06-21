﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }





    }
}