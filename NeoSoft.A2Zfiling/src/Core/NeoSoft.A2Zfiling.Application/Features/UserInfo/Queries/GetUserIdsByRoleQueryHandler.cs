using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries
{
    public class GetUserIdsByRoleQueryHandler : IRequestHandler<GetUserIdsByRoleQuery, Response<List<GetUserIdsByRoleDto>>>
    {
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetUserIdsByRoleQueryHandler(IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Response<List<GetUserIdsByRoleDto>>> Handle(GetUserIdsByRoleQuery request, CancellationToken cancellationToken)
        {
            Response<List<GetUserIdsByRoleDto>> LoggedInUser = null;
            
            var users = await _userManager.GetUsersInRoleAsync(request.Role);

            //var loginDto = _mapper.Map<List<GetUserIdsByRoleDto>>(users);

            var loginDto = users.Select(u => new GetUserIdsByRoleDto { Id = u.Id }).ToList();

            LoggedInUser = new Response<List<GetUserIdsByRoleDto>>(loginDto, "success");

            return LoggedInUser;
        }


    }
}
