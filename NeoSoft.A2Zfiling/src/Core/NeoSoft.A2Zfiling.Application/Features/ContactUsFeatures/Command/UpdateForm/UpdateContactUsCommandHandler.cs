using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContactUsFeatures.Command.UpdateForm
{
    public class UpdateContactUsCommandHandler : IRequestHandler<UpdateContactUsCommand, Response<UpdateContactUsDto>>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<ContactUS> _contactRepsitory;

        public UpdateContactUsCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<ContactUS> contactRepsitory)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
            _contactRepsitory = contactRepsitory;
        }

        public async Task<Response<UpdateContactUsDto>> Handle(UpdateContactUsCommand request, CancellationToken cancellationToken)
        {
            var stateToUpdate = await _contactRepsitory.GetByIdAsync(request.Id);
            if (stateToUpdate == null)
            {
                return new Response<UpdateContactUsDto>("State not found.");
            }
            _mapper.Map(request, stateToUpdate);
            await _contactRepsitory.UpdateAsync(stateToUpdate);
            var updateState = _mapper.Map<UpdateContactUsDto>(stateToUpdate);
            return new Response<UpdateContactUsDto>(updateState, "State Updated Successfully");

        }
    }
}
