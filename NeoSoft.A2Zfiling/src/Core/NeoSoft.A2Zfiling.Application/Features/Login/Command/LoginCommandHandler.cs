using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Login.Command
{
    public class LoginCommandHandler: IRequestHandler<LoginCommand, Response<LoginDto>>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Token> _tokenRepository;
        private readonly IRoleRepository _roleAsyncRepository;
        private readonly IAsyncRepository<UserPermission> _userPermissionRepository;
        private readonly IAsyncRepository<Permission> _permissionRepository;


        public LoginCommandHandler(IAsyncRepository<Permission> permissionRepository,IAsyncRepository<UserPermission> userPermissionRepository,IRoleRepository roleAsyncRepository, IAsyncRepository<Role> roleRepository, IAsyncRepository<Token> tokenRepository , UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,IMapper mapper)
        {
            _userManager=userManager;
            _roleManager=roleManager;
            _configuration=configuration;
            _mapper=mapper;
            _tokenRepository = tokenRepository;
            _roleRepository=roleRepository;
            _roleAsyncRepository = roleAsyncRepository;
            _userPermissionRepository = userPermissionRepository;
            _permissionRepository=permissionRepository;
        }

        public async Task<Response<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Response<LoginDto> loginCommandResponse=null;
            var user = await _userManager.FindByNameAsync(request.Username);
            var checkPassword =  await _userManager.CheckPasswordAsync(user, request.Password);
            if (user != null &&  checkPassword)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var roleString = userRoles.FirstOrDefault();

                var roleCurrent = await _roleAsyncRepository.GetRoleIdAsync(roleString);

                var userId = user.Id;

                var userPermissions = await _userPermissionRepository.ListAllAsync();
                var rolePermissions = userPermissions.Where(x => x.RoleId.ToString() == roleCurrent.RoleId.ToString()).Select(x => x.PermissionId);
                var permissions =( await _permissionRepository.ListAllAsync()).Where(p => rolePermissions.Contains(p.PermissionId));
                var permissionEntityList = permissions.Select(p => (p.ControllerName, p.ActionName)).ToList();


                string permissionsJson = JsonConvert.SerializeObject(permissions);
                //var permissions = await _permissionRepository.ListAllAsync();
                //var filteredPermissions = permissions.Where(x => rolePermissions.Contains(x.PermissionId) && x.ControllerName == controller && x.ActionName == yourAction);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("roleid",roleCurrent.RoleId.ToString()),
                    new Claim("permissions",permissionsJson),
                    new Claim("userId",userId),
                };
                   
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                //foreach (var (controllerName, actionName) in permissionEntityList)
                //{
                //    token.Payload[controllerName] = actionName;
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var token = CreateToken(authClaims);
                var refreshToken = GenerateRefreshToken();
                _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

                //user.Token = token.ToString();
                var tokenEntity = new Token
                {
                    TokenId = token.Id,
                    TokenName = token.ToString(),
                };

                var tokenList = await _tokenRepository.ListAllAsync();

                if (tokenList == null || !tokenList.Any())
                {
                    // If the token list is null or empty, you might want to add the token instead of updating
                    await _tokenRepository.AddAsync(tokenEntity);
                }
                else
                {
                    // Assume you want to update the first token in the list
                    var tokenToUpdate = tokenList.FirstOrDefault();

                    if (tokenToUpdate != null)
                    {
                        // Update the token
                       // tokenToUpdate.PropertyToUpdate = newValue;
                        await _tokenRepository.UpdateAsync(tokenToUpdate);
                    }
                }




                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

                await _userManager.UpdateAsync(user);

                //var token = GetToken(authClaims);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                var expirationString = token.ValidTo;

                var loginDto = _mapper.Map<LoginDto>(user);
                loginDto.Token = tokenString;
                loginDto.Expiration = expirationString;
                loginDto.RefreshToken=refreshToken;
                loginCommandResponse = new Response<LoginDto>(loginDto, "success");



                return loginCommandResponse;
            }
            return new Response<LoginDto>( "Invalid Credentials!!!");
            
        }
        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }


        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
