using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType
{
    public class DeleteLicenseTypeCommand:IRequest<Response<DeleteLicenseTypeDto>>
    {
        public int LicenseTypeId { get; set; }
    }
}
