using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Industry : AuditableEntity
    {
        public int IndustryId { get; set; } 
        public string IndustryName { get; set; }
        public string ShortName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<LicenseMaster> LicenseMasters { get; set; }
    }
}
