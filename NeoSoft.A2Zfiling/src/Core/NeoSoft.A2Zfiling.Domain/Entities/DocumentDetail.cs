using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class DocumentDetail:AuditableEntity
    {
        [Key]
        public int DocumentDetailId { get; set; }

        [ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }

        [ForeignKey("DocumentMaster")]
        public int DocumentMasterId { get; set; }

       
        public string FileName { get; set; }

        public string FileType { get; set; }

        public bool IsActive { get; set; }
    }
}
