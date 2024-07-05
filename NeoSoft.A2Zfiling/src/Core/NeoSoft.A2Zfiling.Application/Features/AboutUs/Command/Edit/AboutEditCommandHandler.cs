using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.TermsAndConditions.Commands.Edit;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.AboutUs.Command.Edit
{
    public class AboutEditCommandHandler : IRequestHandler<AboutEditCommand, Response<AboutEditCommandDTO>>
    {
         private readonly IMapper _mapper;

        private readonly IMessageRepository _messageRepository;
        private readonly IAsyncRepository<AboutUsDetail> _aboutUsDetailRepsitory;

        public AboutEditCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<AboutUsDetail> aboutUsDetailRepsitory)
        {
            _mapper = mapper;

            _messageRepository = messageRepository;
            _aboutUsDetailRepsitory = aboutUsDetailRepsitory;
        }

        public async Task<Response<AboutEditCommandDTO>> Handle(AboutEditCommand request, CancellationToken cancellationToken)
        {

            var serviceReqToUpdate = await _aboutUsDetailRepsitory.GetByIdAsync(1);
            if (serviceReqToUpdate == null)
            {
                return new Response<AboutEditCommandDTO>("ServiceRequest not found.");
            }
            //_mapper.Map(request, serviceReqToUpdate);

            serviceReqToUpdate.About = request.About;

            await _aboutUsDetailRepsitory.UpdateAsync(serviceReqToUpdate);
            var updateServicesContent = _mapper.Map<AboutEditCommandDTO>(serviceReqToUpdate);
            return new Response<AboutEditCommandDTO>(updateServicesContent, " Request Updated Successfully");
        }
    }
}
