using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.CreateSubStatus;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusList
{
    public class SubStatusHandler : IRequestHandler<SubStatusCommand, Response<IEnumerable<SubStatusListDto>>>
    {
        private readonly IAsyncRepository<SubStatus> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<SubStatusHandler> _logger;
        private readonly IAsyncRepository<Status> _statusRepository;

        public SubStatusHandler(IAsyncRepository<SubStatus> asyncRepository, IMapper mapper, ILogger<SubStatusHandler> logger, IAsyncRepository<Status> statusRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _statusRepository = statusRepository;
        }
        public async Task<Response<IEnumerable<SubStatusListDto>>> Handle(SubStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Handler Initiated");
                var allSubStatus = await _asyncRepository.ListAllAsync();

                var substatusList = allSubStatus.Select(x => new SubStatusListDto
                {
                    SubStatusId = x.SubStatusId,
                    SubStatusName=x.SubStatusName,
                    StatusId=x.SubStatusId,
                    StatusName=_statusRepository.GetByIdAsync(x.StatusId)?.Result.StatusName,
                    IsActive=x.IsActive
                }).ToList();

                //var license = _mapper.Map<IEnumerable<LicenseListDto>>(allicense);
                _logger.LogInformation("Handler Completed");
                return new Response<IEnumerable<SubStatusListDto>>(substatusList, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while get all the license ");
                var errorResponse = new Response<IEnumerable<SubStatusListDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
