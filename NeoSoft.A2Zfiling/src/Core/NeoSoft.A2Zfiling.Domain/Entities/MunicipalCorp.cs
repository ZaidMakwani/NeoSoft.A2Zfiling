﻿using NeoSoft.A2Zfiling.Domain.Common;
using Newtonsoft.Json;
using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class MunicipalCorp : AuditableEntity
    public class MunicipalCorp: AuditableEntity
    {
        [Key]
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        public bool IsActive { get; set; }
       
        public int ZoneId { get; set; }
        [JsonIgnore]
        public virtual Zones Zones { get; set; }
        public int StateId { get; set; }
        [JsonIgnore]
        public virtual State State { get; set; }
        public int CityId { get; set; }
        [JsonIgnore]
        public virtual City City { get; set; }
        public virtual ICollection<LicenseMaster> LicenseMasters { get; set; }


    }
}
