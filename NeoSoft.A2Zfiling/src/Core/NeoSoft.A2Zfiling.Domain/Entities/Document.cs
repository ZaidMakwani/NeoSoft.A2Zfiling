using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Document:AuditableEntity
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public bool IsActive { get; set; }
    }
}
