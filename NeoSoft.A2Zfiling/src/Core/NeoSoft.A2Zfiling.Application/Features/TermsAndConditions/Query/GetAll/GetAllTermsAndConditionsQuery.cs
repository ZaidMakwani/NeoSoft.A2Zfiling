using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Query.GetAll
{
    public class GetAllTermsAndConditionsQuery : IRequest<Response<GetAllTermsAndConditionsDto>>
    {
    }
}
