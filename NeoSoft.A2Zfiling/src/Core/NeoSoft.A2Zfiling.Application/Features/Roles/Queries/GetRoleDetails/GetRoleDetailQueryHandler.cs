using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleDetails
{
    public class GetRoleDetailQueryHandler : IRequestHandler<GetRoleDetailsQuery, Response<RolesDto>>
    {
        private readonly IAsyncRepository<Role> _roleRepository;
        
        private readonly IMapper _mapper;

        private readonly IDataProtector _protector;
        public GetRoleDetailQueryHandler(IMapper mapper, IAsyncRepository<Role> roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
           
        }

        public async Task<Response<RolesDto>> Handle(GetRoleDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var id = request.RoleId;
                var @role = await _roleRepository.GetByIdAsync(id);
                var roleDetailDto = _mapper.Map<RolesDto>(@role);

                var roles = await _roleRepository.GetByIdAsync(@role.RoleId);

                if (role == null)
                {
                    throw new NotFoundException(nameof(Role), @role.RoleId);
                }
                var response = new Response<RolesDto>(roleDetailDto);
                if (roles.IsActive)
                {
                    return response;
                }
                else
                {
                    return new Response<RolesDto> { Message = "Not Found" };
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}
