using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.UpdateSubStatus;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus
{
    public class DeleteSubStatusHandler : IRequestHandler<DeleteSubStatusCommand, Response<DeleteSubStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<SubStatus> _asyncRepository;
        private readonly ILogger<DeleteSubStatusHandler> _logger;

        public DeleteSubStatusHandler(IMapper mapper, IAsyncRepository<SubStatus> asyncRepository, ILogger<DeleteSubStatusHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<DeleteSubStatusDto>> Handle(DeleteSubStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeleteSubStatus Handler Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.SubStatusId);
                if (getById == null)
                {
                    return new Response<DeleteSubStatusDto>("Sub Status not found");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeleteSubStatusDto>(getById);
                _logger.LogInformation("DeleteSubStatus Handler Completed");
                return new Response<DeleteSubStatusDto>(deleteData, "SubStatus Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeleteSubStatusDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}
