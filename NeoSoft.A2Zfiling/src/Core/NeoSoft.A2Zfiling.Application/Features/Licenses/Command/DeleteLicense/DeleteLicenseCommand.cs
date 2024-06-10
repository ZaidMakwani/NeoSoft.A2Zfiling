using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense
{
    public class DeleteLicenseCommand:IRequest<Response<DeleteLicenseDto>>
    {
        public int LicenseId { get; set; }
    }
}
