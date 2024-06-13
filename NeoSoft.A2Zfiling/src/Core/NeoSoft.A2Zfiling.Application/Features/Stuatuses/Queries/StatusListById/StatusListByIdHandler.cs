using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusListById
{
    public class StatusListByIdHandler : IRequestHandler<StatusListByIdCommand, Response<StatusListByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Status> _asyncRepository;
        private readonly ILogger<StatusListByIdHandler> _logger;

        public StatusListByIdHandler(IMapper mapper, IAsyncRepository<Status> asyncRepository, ILogger<StatusListByIdHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<StatusListByIdDto>> Handle(StatusListByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetStatusById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.StatusId);
                if (getById == null)
                {
                    return new Response<StatusListByIdDto>("Status not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<StatusListByIdDto>("Status is not active");
                }
                var data = _mapper.Map<StatusListByIdDto>(getById);

                _logger.LogInformation("GetStatusById Completed");
                return new Response<StatusListByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<StatusListByIdDto>(null, $"Error : {ex.Message}");
                return errorMessage;
            }
        }
    }
}
