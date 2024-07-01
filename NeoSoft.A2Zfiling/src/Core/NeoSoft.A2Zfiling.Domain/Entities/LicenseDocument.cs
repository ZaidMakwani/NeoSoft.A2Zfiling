using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class LicenseDocument
    {
        [Key]
        public int LicenseDocumentId { get; set; }
        public int DocumentMasterId { get; set; }
        public int LicenseMasterId { get; set; }
        public LicenseMaster LicenseMaster { get; set; }
        public DocumentMasters DocumentMaster { get; set; }
        public bool IsDeleted { get; set; }
    }
}
