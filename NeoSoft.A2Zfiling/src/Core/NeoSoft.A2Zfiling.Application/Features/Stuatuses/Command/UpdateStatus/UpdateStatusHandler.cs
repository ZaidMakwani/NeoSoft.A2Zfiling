using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.UpdateStatus
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatusCommand, Response<UpdateStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Status> _asyncRepository;
        private readonly ILogger<UpdateStatusHandler> _logger;

        public UpdateStatusHandler(IMapper mapper, IAsyncRepository<Status> asyncRepository, ILogger<UpdateStatusHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateStatusDto>> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateStatus Handler Initiated");

                var statusToUpdate = await _asyncRepository.GetByIdAsync(request.StatusId);
                if (statusToUpdate == null)
                {
                    return new Response<UpdateStatusDto>("Status not found");
                }
                _mapper.Map(request, statusToUpdate);
                await _asyncRepository.UpdateAsync(statusToUpdate);

                var status = _mapper.Map<UpdateStatusDto>(statusToUpdate);

                _logger.LogInformation("UpdateStatus Handler Completed");
                return new Response<UpdateStatusDto>(status, "Permission Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdateStatusDto>(null, $"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}
