using NeoSoft.A2Zfiling.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class Roles:AuditableEntity
    {
        [Key]
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public bool IsActive { get; set; }

    }
}
