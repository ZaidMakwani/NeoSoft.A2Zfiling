using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries
{
    public class GetUserIdsByRoleQuery : IRequest<Response<List<GetUserIdsByRoleDto>>>
    {
        public string Role { get; set; }
    }
}
