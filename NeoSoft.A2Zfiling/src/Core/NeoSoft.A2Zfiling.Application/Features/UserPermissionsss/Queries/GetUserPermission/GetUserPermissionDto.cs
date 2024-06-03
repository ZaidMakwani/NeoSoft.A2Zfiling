using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission
{
    public class GetUserPermissionDto
    {
        public int UserPermissionId { get; set; }

 
        public int RoleId { get; set; }


        public int PermissionId { get; set; }

        public string RoleName { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool? IsActive { get; set; }

    }
}
