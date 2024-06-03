using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Permission : AuditableEntity
    {
        [Key]
        public int PermissionId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool IsActive { get; set; }

    }
}
