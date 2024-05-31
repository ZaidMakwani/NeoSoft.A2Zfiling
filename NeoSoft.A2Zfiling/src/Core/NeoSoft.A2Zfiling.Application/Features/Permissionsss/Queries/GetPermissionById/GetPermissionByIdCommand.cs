using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById
{
    public class GetPermissionByIdCommand:IRequest<Response<GetPermissionByIdDto>>
    {
        public int PermissionId { get; set; }
    }
}
