using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal
{
    public class CreateMunicipalCommand : IRequest<Response<CreateMunicipalDto>>
    {
        public string MunicipalName { get; set; }
        public string Pincode { get; set; }

        public bool IsActive { get; set; }
        public int StateId { get; set; }
        public int? CityId { get; set; }

        public int ZoneId { get; set; }
    }
}
