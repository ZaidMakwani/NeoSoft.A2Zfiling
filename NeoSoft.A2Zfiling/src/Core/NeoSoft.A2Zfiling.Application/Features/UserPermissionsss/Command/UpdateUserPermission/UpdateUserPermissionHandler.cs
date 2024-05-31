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

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission
{
    public class UpdateUserPermissionHandler : IRequestHandler<UpdateUserPermissionCommand, Response<UpdateUserPermissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;
        private readonly ILogger<UpdateUserPermissionHandler> _logger;

        public UpdateUserPermissionHandler(IMapper mapper, IAsyncRepository<UserPermission> asyncRepository, ILogger<UpdateUserPermissionHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdateUserPermissionDto>> Handle(UpdateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("UpdateUserpermission Handler Initiated");

                var permissionToUpdate = await _asyncRepository.GetByIdAsync(request.UserPermissionId);
                if (permissionToUpdate == null)
                {
                    return new Response<UpdateUserPermissionDto>("User Permission not found");
                }
                _mapper.Map(request, permissionToUpdate);
                await _asyncRepository.UpdateAsync(permissionToUpdate);

                var permission = _mapper.Map<UpdateUserPermissionDto>(permissionToUpdate);

                _logger.LogInformation("UpdateUserPermission Handler Completed");
                return new Response<UpdateUserPermissionDto>(permission, "User Permission Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdateUserPermissionDto>(null, $"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}
