using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission
{
    public class DeleteUserPermissionCommand:IRequest<Response<DeleteUserPermissionDto>>
    {
        public int UserPermissionId { get; set; }
    }
}
