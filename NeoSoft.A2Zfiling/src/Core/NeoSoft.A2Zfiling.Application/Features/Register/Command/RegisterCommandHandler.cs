using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Register.Command
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<RegisterDTO>>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<AppUser> _appUserRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAsyncRepository<Role> _roleRepository;
        private readonly RoleManager<IdentityRole> _roleManager;


        public RegisterCommandHandler(RoleManager<IdentityRole> roleManager, IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<AppUser> appUserRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAsyncRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _appUserRepository = appUserRepository;
            this._signInManager = signInManager;
            this._userManager = userManager;
            _signInManager = signInManager;
            _roleRepository = roleRepository;
            _roleManager = roleManager;

        }

        public async Task<Response<RegisterDTO>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            
            
                Response<RegisterDTO> registerMemberCommandResponse = null;
                var userExists = await _userManager.FindByNameAsync(request.UserName);
                var role = await _roleRepository.GetByIdAsync(request.RoleId);
                var roleName = role.RoleName;
                if (userExists != null)
                {
                    registerMemberCommandResponse = new Response<RegisterDTO>("User Alreadly Exists!!");
                }
                else
                {
                    //return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
                    var user = _userManager.CreateAsync(new AppUser()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Address = request.Address,
                        Email = request.Email,
                        PhoneNumber = request.ContactNumber,
                        UserName = request.UserName,
                        RefreshTokenExpiryTime=DateTime.Now,
                        RefreshToken=" "

                    }, request.Password).GetAwaiter().GetResult();
                    if (user.Succeeded)
                    {
                        var Appuser = _appUserRepository.ListAllAsync().Result.FirstOrDefault(x => x.Email == request.Email);
                        AppUser user1 = new AppUser()
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            UserName = request.UserName,
                            Address = request.Address,
                            Email = request.Email,
                            PhoneNumber = request.ContactNumber,
                            RefreshTokenExpiryTime = DateTime.Now,
                            RefreshToken=" "
                        };
                        if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                        {
                            _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                            _userManager.AddToRoleAsync(Appuser, roleName).GetAwaiter().GetResult();
                            registerMemberCommandResponse = new Response<RegisterDTO>(_mapper.Map<RegisterDTO>(user1), "success");
                        }
                        else
                        {
                            _userManager.AddToRoleAsync(Appuser, roleName).GetAwaiter().GetResult();

                            registerMemberCommandResponse = new Response<RegisterDTO>(_mapper.Map<RegisterDTO>(user1), "success");
                        }
                    }
                    else
                    {
                        registerMemberCommandResponse = new Response<RegisterDTO>("Invalid inputs!!");
                    }
                }

                return registerMemberCommandResponse;
            
           
        }
    }
}