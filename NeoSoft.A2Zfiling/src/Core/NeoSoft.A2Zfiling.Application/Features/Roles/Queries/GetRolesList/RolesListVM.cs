using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList
{
    public class RolesListVM
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
        public bool IsActive { get; set; }

    }
}
