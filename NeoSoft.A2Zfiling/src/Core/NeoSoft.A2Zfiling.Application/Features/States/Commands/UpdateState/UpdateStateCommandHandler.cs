using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, Response<UpdateStateDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<State> _stateRepsitory;

        public UpdateStateCommandHandler(IMapper mapper, ICategoryRepository categoryRepository, IMessageRepository messageRepository, IAsyncRepository<State> stateRepsitory)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _messageRepository = messageRepository;
            _stateRepsitory = stateRepsitory;
        }

        public async Task<Response<UpdateStateDto>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var stateToUpdate = await _stateRepsitory.GetByIdAsync(request.StateId);
            if (stateToUpdate == null)
            {
                return new Response<UpdateStateDto>("State not found.");
            }
            _mapper.Map(request, stateToUpdate);
            await _stateRepsitory.UpdateAsync(stateToUpdate);
            var updateState = _mapper.Map<UpdateStateDto>(stateToUpdate);
            return new Response<UpdateStateDto>(updateState, "State Updated Successfully");

        }
    }



}
