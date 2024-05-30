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

namespace NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission
{
    public class GetUserPermissionHandler : IRequestHandler<GetUserPermissionCommand, Response<IEnumerable<GetUserPermissionDto>>>
    {
        private readonly ILogger<GetUserPermissionHandler> _logger;
        private readonly IAsyncRepository<UserPermission> _asyncRepository;
        private readonly IMapper _mapper;

        public GetUserPermissionHandler(ILogger<GetUserPermissionHandler> logger, IAsyncRepository<UserPermission> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<GetUserPermissionDto>>> Handle(GetUserPermissionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get All User Permission Handler Initiated");

                var allpermission = (await _asyncRepository.ListAllAsync()).Where(x => x.IsActive == true);


                var permisssion = _mapper.Map<IEnumerable<GetUserPermissionDto>>(allpermission);

                _logger.LogInformation("Get ALl User Permission Handler Completed");

                return new Response<IEnumerable<GetUserPermissionDto>>(permisssion, "Data Fetched Successfully");
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
