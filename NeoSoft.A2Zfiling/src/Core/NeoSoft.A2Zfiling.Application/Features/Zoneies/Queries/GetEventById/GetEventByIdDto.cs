﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent
{
    public class GetEventByIdDto
    {
        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public bool IsActive { get; set; }
    }
}