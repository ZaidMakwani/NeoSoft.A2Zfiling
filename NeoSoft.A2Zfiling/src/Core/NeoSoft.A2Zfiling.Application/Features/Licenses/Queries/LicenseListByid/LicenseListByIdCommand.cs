using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid
{
    public class LicenseListByIdCommand:IRequest<Response<LicenseListByIdDto>>
    {
        public int LicenseId { get; set; }
    }
}
