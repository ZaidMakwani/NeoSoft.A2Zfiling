using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.RegisterMember
{

    public class RegisterMemberCommandHandler : IRequestHandler<RegisterMemberCommand, Response<RegisterMemberDTO>>
    {
        private readonly IMapper _mapper;
    
        private readonly IMessageRepository _messageRepository;

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;


        public RegisterMemberCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<Industry> industryRepsitory, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _industryRepsitory = industryRepsitory;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<Response<RegisterMemberDTO>> Handle(RegisterMemberCommand request, CancellationToken cancellationToken)
        {
            Response<RegisterMemberDTO> registerMemberCommandResponse = null;


            var member = new AppUser() { FirstName = request.FirstName, LastName = request.LastName, Address = request.Address, Email= request.Email, ContactNumber = request.ContactNumber, Password = request.Password };
            industry = await _industryRepsitory.AddAsync(industry);
            registerMemberCommandResponse = new Response<RegisterMemberDTO>(_mapper.Map<RegisterMemberDTO>(industry), "success");


            return registerMemberCommandResponse;
        }
    }
}
