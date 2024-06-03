using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class UserPermission:AuditableEntity
    {
        public int UserPermissionId { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId {  get; set; }

        public bool IsActive { get; set; }
    }
}
