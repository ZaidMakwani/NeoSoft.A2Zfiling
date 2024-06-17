using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.CreateStatus;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Statuses.Command.CreateStatus
{
    public class CreateStatusCommand:IRequest<Response<CreateStatusDto>>
    {
        public string StatusName { get; set; }
    }
}
