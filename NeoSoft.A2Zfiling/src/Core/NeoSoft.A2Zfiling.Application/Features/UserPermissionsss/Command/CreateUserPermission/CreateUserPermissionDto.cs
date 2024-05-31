using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission
{
    public class CreateUserPermissionDto
    {
        public int UserPermissionId { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }

        public bool? IsActive { get; set; }

        //public string ControllerName { get; set; }

        //public string ActionName { get; set; }
    }
}
