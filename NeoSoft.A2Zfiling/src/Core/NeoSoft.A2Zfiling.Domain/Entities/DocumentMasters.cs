using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    
    public class DocumentMasters:AuditableEntity
    {
        [Key]
        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFormat { get; set; }
        public string SampleFormat { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<LicenseMaster> LicenseMasters { get; set; }
        public virtual ICollection<LicenseDocument> LicenseDocuments { get; set; }
    }
}
