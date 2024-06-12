using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.DeleteStatus
{
    internal class DeleteStatusHandler : IRequestHandler<DeleteStatusCommand, Response<DeleteStatusDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStatusHandler> _logger;
        private readonly IAsyncRepository<Status> _asyncRepository;

        public DeleteStatusHandler(IMapper mapper, ILogger<DeleteStatusHandler> logger, IAsyncRepository<Status> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<DeleteStatusDto>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeleteStatus Handler Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.StatusId);
                if (getById == null)
                {
                    return new Response<DeleteStatusDto>("Status not found");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeleteStatusDto>(getById);
                _logger.LogInformation("DeleteStatus Handler Completed");
                return new Response<DeleteStatusDto>(deleteData, "Status Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeleteStatusDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}
