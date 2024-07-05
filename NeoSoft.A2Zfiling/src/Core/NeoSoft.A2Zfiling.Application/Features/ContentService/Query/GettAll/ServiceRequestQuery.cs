using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContentService.Query.GettAll
{
    public class ServiceRequestQuery : IRequest<Response<ServiceRequestVM>>
    {
    }
}
