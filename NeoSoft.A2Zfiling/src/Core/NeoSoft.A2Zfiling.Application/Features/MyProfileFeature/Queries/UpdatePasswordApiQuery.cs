using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries
{
    public class UpdatePasswordApiQuery : IRequest<Response<AppUsersDto>>
    {
        // Optionally, you can include properties for filtering or pagination
        public string UserId { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
