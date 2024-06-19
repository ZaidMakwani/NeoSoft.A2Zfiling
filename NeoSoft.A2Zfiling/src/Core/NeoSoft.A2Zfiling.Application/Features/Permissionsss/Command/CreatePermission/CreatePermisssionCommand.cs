using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission
{
    public class CreatePermisssionCommand:IRequest<Response<CreatePermissionDto>>
    {
        public string ControllerName { get; set; }

        public string ActionName { get; set; }
        //public string Token { get; set; }
    }
}
