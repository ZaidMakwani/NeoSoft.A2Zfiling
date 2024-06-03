using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.DeleteState
{
    public class DeleteStateCommand : IRequest<Response<DeleteStateDto>>
    {
        public int StateId { get; set; }
    }
}
