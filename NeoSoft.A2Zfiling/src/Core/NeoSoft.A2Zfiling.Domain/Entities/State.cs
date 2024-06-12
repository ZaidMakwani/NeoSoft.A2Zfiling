﻿using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class State: AuditableEntity
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; }
        [JsonIgnore]
        public virtual ICollection<MunicipalCorp> MunicipalCorps { get; set; }

    }
}
