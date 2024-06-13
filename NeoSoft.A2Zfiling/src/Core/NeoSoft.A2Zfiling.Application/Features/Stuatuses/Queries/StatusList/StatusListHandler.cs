using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusList
{
    public class StatusListHandler : IRequestHandler<StatusListCommand, Response<IEnumerable<StatusListDto>>>
    {
        private readonly ILogger<StatusListHandler> _logger;
        private readonly IAsyncRepository<Status> _asyncRepository;
        private readonly IMapper _mapper;

        public StatusListHandler(ILogger<StatusListHandler> logger, IAsyncRepository<Status> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<StatusListDto>>> Handle(StatusListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get All Status Handler Initiated");

                var allStatus = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive == true);

                var status = _mapper.Map<IEnumerable<StatusListDto>>(allStatus);


                _logger.LogInformation("Get ALl Status Handler Completed");

                return new Response<IEnumerable<StatusListDto>>(status, "Data Fetched Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while get all the statu");
                var errorResponse = new Response<IEnumerable<StatusListDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
