using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusListById
{
    public class StatusListByIdCommand:IRequest<Response<StatusListByIdDto>>
    {
        public int StatusId { get; set; }
    }
}
