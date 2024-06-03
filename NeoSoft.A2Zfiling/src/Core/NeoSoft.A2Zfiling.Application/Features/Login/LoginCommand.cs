using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Login
{
    public class LoginCommand : IRequest<Response<LoginDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
