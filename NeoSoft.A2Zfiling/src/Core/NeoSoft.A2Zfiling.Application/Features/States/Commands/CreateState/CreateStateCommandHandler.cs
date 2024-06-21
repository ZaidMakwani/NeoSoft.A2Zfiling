using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Exceptions;
using System.Reflection.Metadata;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;


public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, Response<CreateStateDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<State> _stateRepsitory;

        public CreateStateCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<State> stateRepsitory)
        {
        _mapper = mapper;
            _messageRepository = messageRepository;
        _stateRepsitory = stateRepsitory;
        }

        public async Task<Response<CreateStateDto>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            Response<CreateStateDto> createStateCommandResponse = null;

            var validator = new CreateStateCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var state = new State() { StateName = request.StateName, IsActive=true };
            state = await _stateRepsitory.AddAsync(state);
            createStateCommandResponse = new Response<CreateStateDto>(_mapper.Map<CreateStateDto>(state), "success");
            }

            return createStateCommandResponse;
        }
    }

