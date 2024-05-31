﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityDto
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }
    }
}