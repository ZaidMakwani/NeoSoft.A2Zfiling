using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusListById
{
    public class SubStatusListByIdCommand:IRequest<Response<SubStatusListByIdDto>>
    {
        public int SubStatusId { get; set; }



    }
}
