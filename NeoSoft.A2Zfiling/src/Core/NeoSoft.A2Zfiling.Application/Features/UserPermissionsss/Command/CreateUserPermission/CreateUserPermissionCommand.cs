using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission
{
    public class CreateUserPermissionCommand:IRequest<Response<CreateUserPermissionDto>>
    {

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        [ForeignKey("Permission")]
        public int PermissionId { get; set; }
    }
}
