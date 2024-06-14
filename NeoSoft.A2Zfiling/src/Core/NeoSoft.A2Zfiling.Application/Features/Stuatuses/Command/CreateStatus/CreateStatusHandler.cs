using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.CreateStatus;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Statuses.Command.CreateStatus
{
    public class CreateStatusHandler : IRequestHandler<CreateStatusCommand, Response<CreateStatusDto>>
    {
        private readonly IAsyncRepository<Status> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateStatusHandler> _logger;
        public CreateStatusHandler(IAsyncRepository<Status> asyncRepository, IMapper mapper, ILogger<CreateStatusHandler> logger, IAsyncRepository<Category> categoryRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<CreateStatusDto>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Create Status Handler Initiated");
                Response<CreateStatusDto> response = null;

                var status = new Status()
                {
                    StatusName=request.StatusName,
                    IsActive = true,
                    CreatedBy = "",
                    CreatedDate = DateTime.Now,
                };
                status = await _asyncRepository.AddAsync(status);

                response = new Response<CreateStatusDto>(_mapper.Map<CreateStatusDto>(status), "Status Created Successful.");


                _logger.LogInformation("Create Status Handler Completed");

                return response;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating status");
                var errorResponse = new Response<CreateStatusDto>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
