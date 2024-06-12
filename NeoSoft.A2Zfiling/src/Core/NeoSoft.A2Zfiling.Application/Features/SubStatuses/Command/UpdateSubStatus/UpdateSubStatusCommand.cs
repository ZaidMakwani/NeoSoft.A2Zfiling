using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.UpdateSubStatus
{
    public class UpdateSubStatusCommand:IRequest<Response<UpdateSubStatusDto>>
    {
        public int SubStatusId { get; set; }
        public string SubStatusName { get; set; }

        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public bool IsActive { get; set; }

      
    }
}
