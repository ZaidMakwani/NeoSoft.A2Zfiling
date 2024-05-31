using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList
{
    public class GetPinCodeListQuery:IRequest<Response<IEnumerable<PinCodeListVm>>>
    {

    }
}
