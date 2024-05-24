using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone
{
    public class UpdateZoneCommand:IRequest<Response<UpdateZoneDto>>
    {
        //public UpdateZoneDto UpdateZoneDto { get; set; }
        public int ZoneId { get; set; }

        public string ZoneName { get; set; }

        public bool? IsActive { get; set; }
    }
}
