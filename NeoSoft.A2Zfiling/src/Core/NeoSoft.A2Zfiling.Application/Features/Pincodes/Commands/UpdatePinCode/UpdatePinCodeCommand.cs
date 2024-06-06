using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
//using NeoSoft.A2Zfiling.Application.StateFeatures.UpdateState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.UpdatePinCode
{
    public class UpdatePinCodeCommand : IRequest<Response<UpdatePinCodeDto>>
    {
        public int PinCodeId { get; set; }
        public long PinCodeNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
