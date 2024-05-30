using AutoMapper;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;

using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles
{
    public class UpdateRolesCommandHandler : IRequestHandler<UpdateRolesCommand, Response<RolesDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Role> _roleRepository;

        public UpdateRolesCommandHandler(IAsyncRepository<Role> roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<RolesDto>> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
        {
            var roleToUpdate = await _roleRepository.GetByIdAsync(request.RoleId);
            if (roleToUpdate == null)
            {

                throw new NotFoundException("Not Found", request.RoleId);
            }

            _mapper.Map(request, roleToUpdate);
            roleToUpdate.LastModifiedDate= DateTime.Now;
            
            await _roleRepository.UpdateAsync(roleToUpdate);
            var updateRole = _mapper.Map<RolesDto>(roleToUpdate);

            return new Response<RolesDto>(updateRole, "Role Updated Successfully");
        }

       
    }
}
