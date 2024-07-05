using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.AboutUs.Command.Edit;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.FAQFeatures.Command.Edit
{
    public class FAQEditCommandHandler : IRequestHandler<FAQEditCommand, Response<FAQEditCommandDTO>>
    {
        private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<FAQ> _faqRepsitory;

        public FAQEditCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<FAQ> faqRepsitory)
        {
            _mapper = mapper;

            _messageRepository = messageRepository;
            _faqRepsitory = faqRepsitory;
        }

        public async Task<Response<FAQEditCommandDTO>> Handle(FAQEditCommand request, CancellationToken cancellationToken)
        {

            var serviceReqToUpdate = await _faqRepsitory.GetByIdAsync(1);
            if (serviceReqToUpdate == null)
            {
                return new Response<FAQEditCommandDTO>("ServiceRequest not found.");
            }
            //_mapper.Map(request, serviceReqToUpdate);

            serviceReqToUpdate.FaqDescription = request.FaqDescription;

            await _faqRepsitory.UpdateAsync(serviceReqToUpdate);
            var updateServicesContent = _mapper.Map<FAQEditCommandDTO>(serviceReqToUpdate);
            return new Response<FAQEditCommandDTO>(updateServicesContent, " Request Updated Successfully");
        }
    }
}
