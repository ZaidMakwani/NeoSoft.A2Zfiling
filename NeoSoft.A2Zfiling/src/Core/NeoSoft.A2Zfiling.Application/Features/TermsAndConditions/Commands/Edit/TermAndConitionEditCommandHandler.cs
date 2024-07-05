using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.ContentService.Command.Edit;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Commands.Edit
{
    public class TermAndConitionEditCommandHandler : IRequestHandler<TermAndConitionEditCommand, Response<TermAndConitionEditDTO>>
    {



        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<TermsAndConditionsss> _serviceRequestRepsitory;

        public TermAndConitionEditCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<TermsAndConditionsss> serviceRequestRepsitory)
        {
            _mapper = mapper;

            _messageRepository = messageRepository;
            _serviceRequestRepsitory = serviceRequestRepsitory;
        }

        public async Task<Response<TermAndConitionEditDTO>> Handle(TermAndConitionEditCommand request, CancellationToken cancellationToken)
        {
            var serviceReqToUpdate = await _serviceRequestRepsitory.GetByIdAsync(1);
            if (serviceReqToUpdate == null)
            {
                return new Response<TermAndConitionEditDTO>("ServiceRequest not found.");
            }
            //_mapper.Map(request, serviceReqToUpdate);

            serviceReqToUpdate.TermsDescrption = request.TermsDescrption;

            await _serviceRequestRepsitory.UpdateAsync(serviceReqToUpdate);
            var updateServicesContent = _mapper.Map<TermAndConitionEditDTO>(serviceReqToUpdate);
            return new Response<TermAndConitionEditDTO>(updateServicesContent, "Service Request Updated Successfully");

        }




    }
}
