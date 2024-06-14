using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.UpdateSubStatus
{
    public class UpdateSubStatusHandler : IRequestHandler<UpdateSubStatusCommand, Response<UpdateSubStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SubStatus> _asyncRepository;
        private readonly ILogger<UpdateSubStatusHandler> _logger;

        public UpdateSubStatusHandler(IMapper mapper, IAsyncRepository<SubStatus> asyncRepository, ILogger<UpdateSubStatusHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateSubStatusDto>> Handle(UpdateSubStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateSubStatus Handler Initiated");

                var substatusToUpdate = await _asyncRepository.GetByIdAsync(request.SubStatusId);
                if (substatusToUpdate == null)
                {
                    return new Response<UpdateSubStatusDto>("Sub Status not found");
                }
                _mapper.Map(request, substatusToUpdate);
                await _asyncRepository.UpdateAsync(substatusToUpdate);

                var substatus = _mapper.Map<UpdateSubStatusDto>(substatusToUpdate);

                _logger.LogInformation("UpdateSubStatus Handler Completed");
                return new Response<UpdateSubStatusDto>(substatus, "License Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdateSubStatusDto>(null, $"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}
