﻿using NeoSoft.A2Zfiling.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class City : AuditableEntity
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }

        public int StateId { get; set; }
        [JsonIgnore]
        public virtual State State { get; set; }
        public int ZoneId { get; set; }
        [JsonIgnore]
        public virtual Zones Zones { get; set; }
        [JsonIgnore]
        public virtual ICollection<MunicipalCorp> MunicipalCorps { get; set; }

    }
}