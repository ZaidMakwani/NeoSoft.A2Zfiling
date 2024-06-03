using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById
{
    public class GetUserPermissionByIdCommand:IRequest<Response<GetUserPermissionByIdDto>>
    {
        public int UserPermissionId { get; set; }
    }
}
