using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.CreateSubStatus
{
    public class CreateSubStatusCommand:IRequest<Response<CreateSubStatusDto>>
    {
       

        public string SubStatusName { get; set; }

 
        [ForeignKey("Status")]
        public int StatusId { get; set; }
    }
}
