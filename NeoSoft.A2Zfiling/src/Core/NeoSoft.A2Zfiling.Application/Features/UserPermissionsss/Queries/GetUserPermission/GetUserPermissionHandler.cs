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
//
namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission
{
    public class GetUserPermissionHandler : IRequestHandler<GetUserPermissionCommand, Response<IEnumerable<GetUserPermissionDto>>>
    {
        private readonly ILogger<GetUserPermissionHandler> _logger;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Permission> _asyncRepositoryFactory;
        private readonly IAsyncRepository<Role> _asyncRoles;
        

        public GetUserPermissionHandler(ILogger<GetUserPermissionHandler> logger,
            IAsyncRepository<UserPermission> asyncRepository, IMapper mapper, 
            IAsyncRepository<Permission> asyncRepositoryFactory, IAsyncRepository<Role> asyncRoles)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
            _asyncRepositoryFactory = asyncRepositoryFactory;
            _asyncRoles = asyncRoles;
        }
        public async Task<Response<IEnumerable<GetUserPermissionDto>>> Handle(GetUserPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get All User Permission Handler Initiated");

                var allPermissions = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive==true);

                var getUserPermissionDtos = allPermissions.Select(x => new GetUserPermissionDto
                {
                    UserPermissionId = x.UserPermissionId,
                    RoleId = x.RoleId,
                    RoleName = _asyncRoles.GetByIdAsync(x.RoleId)?.Result?.RoleName,
                    PermissionId = x.PermissionId,
                    ControllerName = _asyncRepositoryFactory.GetByIdAsync(x.PermissionId)?.Result?.ControllerName,
                    ActionName = _asyncRepositoryFactory.GetByIdAsync(x.PermissionId)?.Result?.ActionName,
                    IsActive = x.IsActive
                }).ToList();

                _logger.LogInformation("Get ALl User Permission Handler Completed");
                return new Response<IEnumerable<GetUserPermissionDto>>(getUserPermissionDtos, "Data Fetched Successfully");

            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while get all the user permission");
                var errorResponse = new Response<IEnumerable<GetUserPermissionDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
