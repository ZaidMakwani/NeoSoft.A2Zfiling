using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState
{
    public class UpdateStateCommand : IRequest<Response<UpdateStateDto>>
    {
        public int StateId { get; set; }
        public string StateName { get; set; }

        public bool IsActive { get; set; }
    }
}
