using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Queries.GetAllLicense
{
    public class GetAllLicenseMasterQuery: IRequest<Response<IEnumerable<GetAllLicenseMasterVM>>>
    {
    }
}
