using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
//using NeoSoft.A2Zfiling.Application.StateFeatures.DeleteState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.DeletePinCode
{
    public class DeletePinCodeCommand : IRequest<Response<DeletePinCodeDto>>
    {
        public int PinCodeId { get; set; }
        public long PinCodeNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
