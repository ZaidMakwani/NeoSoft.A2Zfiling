using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense
{
    public class CreateLicenseCommand:IRequest<Response<CreateLicenseDto>>
    {
       

        public string LicenseName { get; set; }

        public string ShortName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public ShortList ShortList { get; set; }
     
    }
}
