using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Userdetails.Queries.GetUserDetailsList
{
    public class GetUserDetailsListQuery:IRequest<Response<IEnumerable<GetUserDetailsListDto>>>
    {
       
    }
}
