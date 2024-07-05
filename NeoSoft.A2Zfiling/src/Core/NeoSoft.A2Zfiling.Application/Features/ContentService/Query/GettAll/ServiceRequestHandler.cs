using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.ContentService.Query.GettAll
{
    public class ServiceRequestHandler:IRequestHandler<ServiceRequestQuery, Response<ServiceRequestVM>>
  
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ServiceRequestHandler> _logger;
        private readonly IAsyncRepository<ServiceRequest> _serviceRequestRepository;

        public ServiceRequestHandler(IMapper mapper, ILogger<ServiceRequestHandler> logger, IAsyncRepository<ServiceRequest> serviceRequestRepository)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<Response<ServiceRequestVM>> Handle(ServiceRequestQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var serviceRequest = (await _serviceRequestRepository.ListAllAsync());

            var serviceRe = _mapper.Map<ServiceRequestVM>(serviceRequest[0]);

            _logger.LogInformation("Hanlde Completed");
            return new Response<ServiceRequestVM>(serviceRe, "Data Fetched Successfully");
        }

      
    }
}
