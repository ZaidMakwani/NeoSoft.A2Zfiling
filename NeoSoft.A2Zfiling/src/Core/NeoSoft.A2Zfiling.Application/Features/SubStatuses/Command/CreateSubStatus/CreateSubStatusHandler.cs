using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.CreateSubStatus
{
    public class CreateSubStatusHandler : IRequestHandler<CreateSubStatusCommand, Response<CreateSubStatusDto>>
    {
        private readonly IAsyncRepository<SubStatus> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSubStatusHandler> _logger;
        private readonly IAsyncRepository<Status> _statusRepository;

        public CreateSubStatusHandler(IAsyncRepository<SubStatus> asyncRepository, IMapper mapper, ILogger<CreateSubStatusHandler> logger, IAsyncRepository<Status> statusRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _statusRepository = statusRepository;
        }
        public async Task<Response<CreateSubStatusDto>> Handle(CreateSubStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");


                var status = await _statusRepository.GetByIdAsync(request.StatusId);
                if (status == null || !status.IsActive)
                {
                    return new Response<CreateSubStatusDto>(null, "Status is inactive or not allowed.");
                }

                var subStatus = new SubStatus()
                {
                   SubStatusName=request.SubStatusName,
                   StatusId=request.StatusId,
                    IsActive = true,
                    CreatedBy = "Admin",
                    CreatedDate = DateTime.Now,
                };
                var data = await _asyncRepository.AddAsync(subStatus);

                var result = _mapper.Map<CreateSubStatusDto>(data);


                _logger.LogInformation("Handler Completed");
                return new Response<CreateSubStatusDto>(result, "SubStatus  Inserted Successfully"); ;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating a sub status ");
                var errorResponse = new Response<CreateSubStatusDto>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
