using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission
{
    public class CreateUserPermissionHandler : IRequestHandler<CreateUserPermissionCommand, Response<CreateUserPermissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;
        private readonly ILogger<CreateUserPermissionHandler> _logger;
        private readonly IAsyncRepository<Role> _roleRespository;
        private readonly IAsyncRepository<Permission> _permissionRespository;

        public CreateUserPermissionHandler(IAsyncRepository<Role> roleRespository, IAsyncRepository<Permission> permissionRespository
        ,IMapper mapper, IAsyncRepository<UserPermission> asyncRepository, ILogger<CreateUserPermissionHandler> logger)
        {
            _permissionRespository = permissionRespository;
            _roleRespository = roleRespository;
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<CreateUserPermissionDto>> Handle(CreateUserPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Create UserPermission Handler Initiated");
                Response<CreateUserPermissionDto> response = null;

                var role = await _roleRespository.GetByIdAsync(request.RoleId);
                if (role == null || !role.IsActive)
                {
                    return new Response<CreateUserPermissionDto>(null, "Role is inactive or not allowed.");
                }

                var permissionData = await _permissionRespository.GetByIdAsync(request.PermissionId);
                if (permissionData == null || !permissionData.IsActive)
                {
                    return new Response<CreateUserPermissionDto>(null, "Permission is inactive or not allowed.");
                }
                var permission = new UserPermission()
                {
                    RoleId=request.RoleId,
                    PermissionId=request.PermissionId,
                    IsActive = true,
                    CreatedBy = "",
                    CreatedDate = DateTime.Now,
                };
                permission = await _asyncRepository.AddAsync(permission);

                response = new Response<CreateUserPermissionDto>(_mapper.Map<CreateUserPermissionDto>(permission), "Permission Created Successful.");


                _logger.LogInformation("Create UserPermission Handler Completed");

                return response;
            }

            catch (Exception ex)
            {
                _logger.LogError("Error occurred while creating userpermission");
                var errorResponse = new Response<CreateUserPermissionDto>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
