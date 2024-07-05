using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries
{
    public class GetUserIdByEmailQueryHandler : IRequestHandler<GetUserIdByEmailQuery, Response<GetUserIdByEmailDto>>
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public GetUserIdByEmailQueryHandler(IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Response<GetUserIdByEmailDto>> Handle(GetUserIdByEmailQuery request, CancellationToken cancellationToken)
        {
            Response<GetUserIdByEmailDto> LoggedInUser = null;


            var user = await _userManager.FindByEmailAsync(request.Email);

            var loginDto = _mapper.Map<GetUserIdByEmailDto>(user);

            LoggedInUser = new Response<GetUserIdByEmailDto>(loginDto, "success");

            return LoggedInUser;
        }
    }
}
