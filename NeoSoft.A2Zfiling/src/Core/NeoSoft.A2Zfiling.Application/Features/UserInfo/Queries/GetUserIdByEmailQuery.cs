using MediatR;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries
{
    public class GetUserIdByEmailQuery : IRequest<Response<GetUserIdByEmailDto>>
    {
        public string Email { get; set; }
    }
}
