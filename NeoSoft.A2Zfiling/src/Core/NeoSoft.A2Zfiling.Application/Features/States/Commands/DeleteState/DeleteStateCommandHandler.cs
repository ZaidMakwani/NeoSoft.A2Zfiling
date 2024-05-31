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

namespace NeoSoft.A2Zfiling.Application.Features.States.Commands.DeleteState
{
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, Response<DeleteStateDto>>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<State> _stateRepsitory;

        public DeleteStateCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<State> stateRepsitory)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _stateRepsitory = stateRepsitory;
        }

        public async Task<Response<DeleteStateDto>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            Response<DeleteStateDto> deleteStateCommandResponse = null;

            var industry = await _stateRepsitory.GetByIdAsync(request.StateId);

            if (industry == null)
            {
                return new Response<DeleteStateDto>("State not found");
            }

            industry.IsActive = false;
            industry.LastModifiedDate = DateTime.Now;
            await _stateRepsitory.UpdateAsync(industry);

            var deleteIndustryDto = _mapper.Map<DeleteStateDto>(industry);

            return new Response<DeleteStateDto>(deleteIndustryDto, "State Deleted Successfully");
        }
    }
}
