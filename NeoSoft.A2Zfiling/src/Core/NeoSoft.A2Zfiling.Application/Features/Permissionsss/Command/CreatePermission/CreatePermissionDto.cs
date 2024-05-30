﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission
{
    public class CreatePermissionDto
    {
        public int PermissionId { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public bool? IsActive { get; set; }
    }
}