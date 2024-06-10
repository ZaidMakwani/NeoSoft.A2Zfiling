using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid
{
    public class LicenseListByIdDto
    {
        public int LicenseId { get; set; }


        public string LicenseName { get; set; }


        public string ShortName { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        public string CategoryName { get; set; }
        public string ShortList { get; set; }

        public bool IsActive { get; set; }
    }
}
