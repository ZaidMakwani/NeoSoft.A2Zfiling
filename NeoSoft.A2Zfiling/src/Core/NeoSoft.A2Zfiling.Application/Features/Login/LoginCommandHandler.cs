using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<LoginDto>>
    {
        private readonly IMapper _mapper;
        
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<LoginDto> _loginRepsitory;


        public LoginCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<LoginDto> loginRepsitory)
        {
            _mapper = mapper;
            
            _messageRepository = messageRepository;
            _loginRepsitory = loginRepsitory;
        }
        public async Task<Response<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Response<LoginDto> LoginCommandResponse = null;


            var login = new LoginDto() { Username = request.Username};
            login = await _loginRepsitory.AddAsync(login);
            LoginCommandResponse = new Response<LoginDto>(_mapper.Map<LoginDto>(login), "success");


            return LoginCommandResponse;
        }

    }


}
