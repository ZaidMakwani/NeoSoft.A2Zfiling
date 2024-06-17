using NeoSoft.A2Zfiling.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class LicenseType:AuditableEntity
    {
        [Key]
        public int LicenseTypeId { get; set; }

        public string LicenseName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
        [JsonIgnore]
        public virtual ICollection<LicenseMaster> LicenseMasters { get; set; }
    }
}
