using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.UpdateStatus
{
    public class UpdateStatusDto
    {

        public int StatusId { get; set; }

        public string StatusName { get; set; }

        public bool? IsActive { get; set; }
    }
}
