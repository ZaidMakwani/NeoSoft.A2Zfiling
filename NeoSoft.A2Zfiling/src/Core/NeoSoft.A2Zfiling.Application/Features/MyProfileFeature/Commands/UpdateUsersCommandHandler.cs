using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.Login.Command;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Commands
{
    public class UpdateUserDetailsHandler : IRequestHandler<UpdateUsersCommand, Response<UpdateUsersDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly UserManager<AppUser> _userManager;

        public UpdateUserDetailsHandler(IMapper mapper, IMessageRepository messageRepository, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _messageRepository = messageRepository;
          
        }

        public async Task<Response<UpdateUsersDto>> Handle(UpdateUsersCommand request, CancellationToken cancellationToken)
        {
            Response<UpdateUsersDto> UpdatedUser = null;
            var user = await _userManager.FindByIdAsync(request.AppUserId.ToString());
            if (user == null)
            {
                return new Response<UpdateUsersDto>
                {
                   
                    Message = "User not found."
                };
            }

            // Update user properties
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.Address = request.Address;
            user.LastName = request.LastName;  
            user.FirstName = request.FirstName;
            //user.PhoneNumber = request.ContactNumber;

            // Attempt to update the user
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                // Collect errors and return a failure response
                var loginDto = _mapper.Map<UpdateUsersDto>(user);

                UpdatedUser = new Response<UpdateUsersDto>(loginDto, "success");
                return UpdatedUser;
            }

            // Map the updated user to the DTO
            var updatedUserDto = _mapper.Map<UpdateUsersDto>(user);

            // Return a success response
            UpdatedUser = new Response<UpdateUsersDto>(updatedUserDto, "success");
            return UpdatedUser;

        }
    }
}
