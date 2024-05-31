using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById
{
    public class GetUserPermisssionByIdHandler : IRequestHandler<GetUserPermissionByIdCommand, Response<GetUserPermissionByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;
        private readonly ILogger<GetUserPermisssionByIdHandler> _logger;

        public GetUserPermisssionByIdHandler(IMapper mapper, IAsyncRepository<UserPermission> asyncRepository, ILogger<GetUserPermisssionByIdHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetUserPermissionByIdDto>> Handle(GetUserPermissionByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetUserPermissionById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.UserPermissionId);
                if (getById == null)
                {
                    return new Response<GetUserPermissionByIdDto>("User Permission not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetUserPermissionByIdDto>("User Permission is not active");
                }
                var data = _mapper.Map<GetUserPermissionByIdDto>(getById);

                _logger.LogInformation("GetUserPermissionById Completed");
                return new Response<GetUserPermissionByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<GetUserPermissionByIdDto>(null, $"Error : {ex.Message}");
                return errorMessage;
            }
        }
    }
}
