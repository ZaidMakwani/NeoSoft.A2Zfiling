using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense
{
    public class UpdateLicenseCommand: IRequest<Response<UpdateLicenseDto>>
    {
        public int LicenseId { get; set; }

        public string LicenseName { get; set; }
        public string ShortName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        public ShortList ShortList { get; set; }

        public bool? IsActive { get; set; }
    }
}
