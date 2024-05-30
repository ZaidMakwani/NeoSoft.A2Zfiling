using MediatR;

using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailsQuery: IRequest<Response<RolesDto>>
    {
        public int RoleId { get; set; }
    }
}
