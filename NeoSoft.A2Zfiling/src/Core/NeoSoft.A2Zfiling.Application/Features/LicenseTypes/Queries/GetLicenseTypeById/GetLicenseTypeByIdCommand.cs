using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById
{
    public class GetLicenseTypeByIdCommand:IRequest<Response<GetLicenseTypeByIdDto>>
    {
        public int LicenseTypeId { get; set; }
    }
}
