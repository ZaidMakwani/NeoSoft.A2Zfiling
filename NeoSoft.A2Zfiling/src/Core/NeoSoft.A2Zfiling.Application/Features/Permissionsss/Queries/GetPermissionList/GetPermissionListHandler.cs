using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList
{
    public class GetPermissionListHandler : IRequestHandler<GetPermissionListCommand, Response<IEnumerable<GetPermissionListDto>>>
    {
        private readonly ILogger<GetPermissionListHandler> _logger;
        private readonly IAsyncRepository<Permission> _asyncRepository;
        private readonly IMapper _mapper;

        public GetPermissionListHandler(ILogger<GetPermissionListHandler> logger, IAsyncRepository<Permission> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<GetPermissionListDto>>> Handle(GetPermissionListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Get All Permission Handler Initiated");

                var allpermission =( await _asyncRepository.ListAllAsync()).Where(x=>x.IsActive==true);

                var permisssion = _mapper.Map<IEnumerable<GetPermissionListDto>>(allpermission);
                

                _logger.LogInformation("Get ALl Permission Handler Completed");

                return new Response<IEnumerable<GetPermissionListDto>>(permisssion,"Data Fetched Successfully");
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occurred while get all the permission");
                var errorResponse = new Response<IEnumerable<GetPermissionListDto>>(null, $"Error: {ex.Message}");
                return errorResponse;
            }
        }
    }
}
