using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles
{
   
    public class CreateRolesCommandHandler : IRequestHandler<CreateRolesCommand, Response<CreateRolesDto>>
    
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Role> _aysncRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateRolesCommandHandler(IMapper mapper, IAsyncRepository<Role> aysncRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _aysncRepository = aysncRepository;
        }
        public async Task<Response<CreateRolesDto>> Handle(CreateRolesCommand request, CancellationToken cancellationToken)
        {
            Response<CreateRolesDto> createRolesCommandResponse = null;

            var validator = new CreateRolesCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var roles = new Role() { RoleName = request.RoleName,IsActive=true,CreatedDate=DateTime.Now };
                roles = await _aysncRepository.AddAsync(roles);
                createRolesCommandResponse = new Response<CreateRolesDto>(_mapper.Map<CreateRolesDto>(roles), "success");
            }

            return createRolesCommandResponse;
        }
    }
}
