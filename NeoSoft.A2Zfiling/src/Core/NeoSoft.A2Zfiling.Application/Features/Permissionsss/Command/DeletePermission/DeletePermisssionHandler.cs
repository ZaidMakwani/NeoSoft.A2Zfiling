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

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission
{
    public class DeletePermisssionHandler : IRequestHandler<DeletePermissionCommand, Response<DeletePermissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePermisssionHandler> _logger;
        private readonly IAsyncRepository<Permission> _asyncRepository;

        public DeletePermisssionHandler(IMapper mapper, ILogger<DeletePermisssionHandler> logger, IAsyncRepository<Permission> asyncRepository)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<DeletePermissionDto>> Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("DeletePermission Handler Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.PermissionId);
                if(getById == null)
                {
                    return new Response<DeletePermissionDto>("Permission not found");
                }
                getById.IsActive = false;
                getById.LastModifiedBy = "";
                getById.LastModifiedDate = DateTime.Now;

              await _asyncRepository.UpdateAsync(getById);

                var deleteData = _mapper.Map<DeletePermissionDto>(getById);
                _logger.LogInformation("DeletePermission Handler Completed");
                return new Response<DeletePermissionDto>(deleteData, "Permission Deleted Successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the data");
                var errorMessage = new Response<DeletePermissionDto>($"Error:{ex.Message}");
                return errorMessage;
            }
        }
    }
}
