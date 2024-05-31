using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission
{
    public class UpdateUserPermissionCommand:IRequest<Response<UpdateUserPermissionDto>>
    {
        public int UserPermissionId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public bool? IsActive { get; set; }
    }
}
