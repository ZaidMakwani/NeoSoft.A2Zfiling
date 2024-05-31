using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission
{
    public class DeleteUserPermissionByIdHandler : IRequestHandler<DeleteUserPermissionCommand, Response<DeleteUserPermissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserPermissionByIdHandler> _logger;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;

        public DeleteUserPermissionByIdHandler(IMapper mapper, ILogger<DeleteUserPermissionByIdHandler> logger, IAsyncRepository<UserPermission> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<DeleteUserPermissionDto>> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeleteUserPermission Handler Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.UserPermissionId);
                if (getById == null)
                {
                    return new Response<DeleteUserPermissionDto>("User Permission not found");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

                await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeleteUserPermissionDto>(getById);
                _logger.LogInformation("DeleteUserPermission Handler Completed");
                return new Response<DeleteUserPermissionDto>(deleteData, "User Permission Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeleteUserPermissionDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}
