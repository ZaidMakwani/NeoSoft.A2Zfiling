using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion
{
    public class UpdatePermissionHandler : IRequestHandler<UpdatePermissionCommand, Response<UpdatePermissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Permission> _asyncRepository;
        private readonly ILogger<UpdatePermissionHandler> _logger;

        public UpdatePermissionHandler(IMapper mapper, IAsyncRepository<Permission> asyncRepository, ILogger<UpdatePermissionHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<UpdatePermissionDto>> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Updatepermission Handler Initiated");

                var permissionToUpdate = await _asyncRepository.GetByIdAsync(request.PermissionId);
                if(permissionToUpdate == null)
                {
                    return new Response<UpdatePermissionDto>("Permission not found");
                }
                _mapper.Map(request, permissionToUpdate);
                await _asyncRepository.UpdateAsync(permissionToUpdate);

                var permission = _mapper.Map<UpdatePermissionDto>(permissionToUpdate);

                _logger.LogInformation("UpdatePermission Handler Completed");
                return new Response<UpdatePermissionDto>(permission,"Permission Updated Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the data");
                var errorMessage = new Response<UpdatePermissionDto>(null,$"Error: {ex.Message}");
                return errorMessage;
            }
        }
    }
}
