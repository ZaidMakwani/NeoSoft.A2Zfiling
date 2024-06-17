using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType
{
    public class CreateLicenseTypeCommand:IRequest<Response<CreateLicenseTypeDto>>
    {
    
        public string LicenseName { get; set; }

        public string Description { get; set; }


    }
}
