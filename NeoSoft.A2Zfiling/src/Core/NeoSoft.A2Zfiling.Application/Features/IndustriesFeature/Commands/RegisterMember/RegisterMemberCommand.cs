using MediatR;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.RegisterMember
{
    public class RegisterMemberCommand : IRequest<Response<RegisterMemberDTO>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
