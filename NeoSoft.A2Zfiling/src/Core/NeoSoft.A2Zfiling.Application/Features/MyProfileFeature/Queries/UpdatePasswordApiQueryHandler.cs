using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries
{
    public class UpdatePasswordApiHandler : IRequestHandler<UpdatePasswordApiQuery, Response<AppUsersDto>>
    {

        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdatePasswordApiHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<AppUsersDto>> Handle(UpdatePasswordApiQuery request, CancellationToken cancellationToken)
        {
            Response<AppUsersDto> LoggedInUser = null;


            var user = await _userManager.FindByIdAsync(request.UserId);

            user.PasswordCurr = request.ConfirmPassword;

            var result = await _userManager.ChangePasswordAsync(user, user.PasswordCurr, request.ConfirmPassword);

            _userManager.UpdateAsync(user);

            var loginDto = _mapper.Map<AppUsersDto>(user);

            LoggedInUser = new Response<AppUsersDto>(loginDto, "success");

            return LoggedInUser;
        }
    }
}
