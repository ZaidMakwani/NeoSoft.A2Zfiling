using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.Login.Command;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUsersDetailQuery, Response<AppUsersDto>>
    {

        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserDetailQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Response<AppUsersDto>> Handle(GetUsersDetailQuery request, CancellationToken cancellationToken)
        {
            Response<AppUsersDto> LoggedInUser = null;


            var user = await _userManager.FindByIdAsync(request.UserId);

            var loginDto = _mapper.Map<AppUsersDto>(user);

            LoggedInUser = new Response<AppUsersDto>(loginDto, "success");

            return LoggedInUser;
        }
    }
}

public class JwtDecoder
{
    public static ClaimsPrincipal DecodeJwtToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(token);

        return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims));
    }
}
