using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Delete
{
    public class DeleteLicenseMasterCommand : IRequest
    {
        public int LicenseMasterId { get; set; }
    }
}
