using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusListById
{
    public class SubStatusListByIdHandler : IRequestHandler<SubStatusListByIdCommand, Response<SubStatusListByIdDto>>
    {
        private readonly IAsyncRepository<SubStatus> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SubStatusListByIdHandler> _logger;
        private readonly IAsyncRepository<Status> _statusRepository;

        public SubStatusListByIdHandler(IAsyncRepository<SubStatus> asyncRepository, IMapper mapper, ILogger<SubStatusListByIdHandler> logger, IAsyncRepository<Status> statusRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _statusRepository = statusRepository;
        }
        public async Task<Response<SubStatusListByIdDto>> Handle(SubStatusListByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetSubStatusById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.SubStatusId);
                if (getById == null)
                {
                    return new Response<SubStatusListByIdDto>(" Sub Status not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<SubStatusListByIdDto>("License is not active");
                }
                var statusName = await _statusRepository.GetByIdAsync(getById.StatusId);
                if (statusName == null)
                {
                    return new Response<SubStatusListByIdDto>("Status not found");
                }

                var data = _mapper.Map<SubStatusListByIdDto>(getById);
                data.StatusName = statusName.StatusName;

                _logger.LogInformation("GetSubStatusById Completed");
                return new Response<SubStatusListByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<SubStatusListByIdDto>(null, $"Error : {ex.Message}");
                return errorMessage;
            }
        }
    }
}
