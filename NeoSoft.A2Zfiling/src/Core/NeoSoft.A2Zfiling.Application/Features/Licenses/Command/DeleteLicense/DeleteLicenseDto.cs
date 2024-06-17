using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense
{
    public class DeleteLicenseDto
    {
        public int LicenseId { get; set; }


        public string LicenseName { get; set; }


        public string ShortName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public ShortList ShortList { get; set; }

        public bool IsActive { get; set; }
    }
}
