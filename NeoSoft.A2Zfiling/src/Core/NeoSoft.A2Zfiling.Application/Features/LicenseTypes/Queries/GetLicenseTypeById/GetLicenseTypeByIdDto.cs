using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById
{
    public class GetLicenseTypeByIdDto
    {
        public int LicenseTypeId { get; set; }
        public string LicenseName { get; set; }
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
