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

namespace NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById
{
    public class GetPermissionByIdHandler : IRequestHandler<GetPermissionByIdCommand, Response<GetPermissionByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Permission> _asyncRepository;
        private readonly ILogger<GetPermissionByIdHandler> _logger;

        public GetPermissionByIdHandler(IMapper mapper, IAsyncRepository<Permission> asyncRepository, ILogger<GetPermissionByIdHandler> logger)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetPermissionByIdDto>> Handle(GetPermissionByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetPermissionById Initiated");

                var getById = await _asyncRepository.GetByIdAsync(request.PermissionId);
                if(getById== null)
                {
                    return new Response<GetPermissionByIdDto>("Permission not found");
                }
                if (getById.IsActive != true)
                {
                    return new Response<GetPermissionByIdDto>("Permission is not active");
                }
                var data = _mapper.Map<GetPermissionByIdDto>(getById);

                _logger.LogInformation("GetPermissionById Completed");
                return new Response<GetPermissionByIdDto>(data, "Data Found Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting a particular data");
                var errorMessage = new Response<GetPermissionByIdDto>(null,$"Error : {ex.Message}");
                return errorMessage;
            }
        }
    }
}
