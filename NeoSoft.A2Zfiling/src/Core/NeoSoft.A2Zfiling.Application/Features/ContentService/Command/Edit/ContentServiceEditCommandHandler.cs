using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContentService.Command.Edit
{
    public class ContentServiceEditCommandHandler:IRequestHandler<ContentServiceEditCommand, Response<ContentServiceEditDTO>>
    {


        
            private readonly IMapper _mapper;

            private readonly IMessageRepository _messageRepository;
            private readonly IAsyncRepository<ServiceRequest> _serviceRequestRepsitory;

            public ContentServiceEditCommandHandler(IMapper mapper, IMessageRepository messageRepository, IAsyncRepository<ServiceRequest> serviceRequestRepsitory)
            {
                _mapper = mapper;

                _messageRepository = messageRepository;
            _serviceRequestRepsitory= serviceRequestRepsitory;
            }

            public async Task<Response<ContentServiceEditDTO>> Handle(ContentServiceEditCommand request, CancellationToken cancellationToken)
            {
            var serviceReqToUpdate = await _serviceRequestRepsitory.GetByIdAsync(1);
                if (serviceReqToUpdate == null)
                {
                    return new Response<ContentServiceEditDTO>("ServiceRequest not found.");
                }
            //_mapper.Map(request, serviceReqToUpdate);

            serviceReqToUpdate.AboutUs = request.AboutUs;

            await _serviceRequestRepsitory.UpdateAsync(serviceReqToUpdate);
            var updateServicesContent = _mapper.Map<ContentServiceEditDTO>(serviceReqToUpdate);
            return new Response<ContentServiceEditDTO>(updateServicesContent, "Service Request Updated Successfully");

            }




    }

}
