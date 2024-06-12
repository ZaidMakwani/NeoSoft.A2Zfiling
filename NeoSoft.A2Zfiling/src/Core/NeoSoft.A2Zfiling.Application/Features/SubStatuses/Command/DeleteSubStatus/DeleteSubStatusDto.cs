﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus
{
    public class DeleteSubStatusDto
    {
        public int SubStatusId { get; set; }

        public string SubStatusName { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
    }
}