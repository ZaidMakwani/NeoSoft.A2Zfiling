﻿using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone
{
    public class DeleteZoneCommand : IRequest<Response<DeleteZoneDto>>
    {
        public int ZoneId { get; set; }
    }
}