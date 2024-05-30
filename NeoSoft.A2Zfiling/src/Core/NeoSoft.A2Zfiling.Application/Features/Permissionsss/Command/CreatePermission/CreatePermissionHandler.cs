using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission
{
    public class CreatePermissionHandler : IRequestHandler<CreatePermisssionCommand, Response<CreatePermissionDto>>
    {
        private readonly IMapper _mapper; 
        private readonly IAsyncRepository<Permission> _asyncRepository;
        private readonly ILogger<CreatePermissionHandler> _logger;

        public CreatePermissionHandler(IMapper mapper, IAsyncRepository<Permission> asyncRepository, ILogger<CreatePermissionHandler> logger)    
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<CreatePermissionDto>> Handle(CreatePermisssionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Create Permission Handler Initiated");
                Response<CreatePermissionDto> response = null;

                var permission = new Permission()
                {
                    ActionName = request.ActionName,
                    ControllerName = request.ControllerName,
                    IsActive = true,
                    CreatedBy = "",
                    CreatedDate = DateTime.Now,
                };
                permission =await _asyncRepository.AddAsync(permission);

                response = new Response<CreatePermissionDto>(_mapper.Map<CreatePermissionDto>(permission), "Permission Created Successful.");


                _logger.LogInformation("Create Permission Handler Completed");

                return response;
            }

            catch(Exception ex)
            {
                _logger.LogError("Error occurred while creating permission");
                var errorResponse = new Response<CreatePermissionDto>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
