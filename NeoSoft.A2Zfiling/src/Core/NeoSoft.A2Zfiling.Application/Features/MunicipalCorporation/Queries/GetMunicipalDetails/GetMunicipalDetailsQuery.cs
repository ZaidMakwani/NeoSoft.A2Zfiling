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
        public int CityId { get; set; }
        public int ZoneId { get; set; }
        public int StateId { get; set; }
        public string? Pincode { get; set; }

    }
}
