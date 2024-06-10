﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType
{
    public class DeleteLicenseTypeDto
    {
        public int LicenseTypeId { get; set; }
        public string LicenseName { get; set; }
        public string Description { get; set; }

        public bool? IsActive { get; set; }
    }
}