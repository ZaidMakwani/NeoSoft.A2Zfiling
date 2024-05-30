using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission
{
    public class DeletePermissionCommand:IRequest<Response<DeletePermissionDto>>
    {
        public int PermissionId { get; set; }
    }
}
