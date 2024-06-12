using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Status:AuditableEntity
    {
        [Key]
        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public bool IsActive { get; set; }
    }
}
