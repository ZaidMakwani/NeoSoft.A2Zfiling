using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList
{
    public class StateListVm
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        //public int ZoneId { get; set; }
        //public int ZoneName { get; set; }
        //public virtual Zones Zones { get; set; }


    }
}
