using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails
{
    public class GetMunicipalDetailsQuery : IRequest<Response<GetMunicipalDto>>

    {
        public int MunicipalId { get; set; }
    }
}
