using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.DeleteStatus
{
    public class DeleteStatusCommand:IRequest<Response<DeleteStatusDto>>
    {
        public int StatusId { get; set; }
    }
}
