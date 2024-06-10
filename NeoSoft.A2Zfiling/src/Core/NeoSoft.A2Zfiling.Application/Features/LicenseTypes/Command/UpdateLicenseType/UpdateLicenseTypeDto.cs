using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType
{
    public class UpdateLicenseTypeDto
    {
        public int LicenseTypeId { get; set; }

        [Required]
        [MaxLength(500)]
        public string LicenseName { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
