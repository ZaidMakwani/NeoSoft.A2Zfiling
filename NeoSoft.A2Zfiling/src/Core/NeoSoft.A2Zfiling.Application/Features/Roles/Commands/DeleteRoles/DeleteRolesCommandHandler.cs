using AutoMapper;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.DeleteRoles;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteRoles
{
    public class DeleteRolesCommandHandler : IRequestHandler<DeleteRolesCommand>
    {
        private readonly IAsyncRepository<Role> _rolesRepository;

        public DeleteRolesCommandHandler(IAsyncRepository<Role> rolesRepository)
        {             
            _rolesRepository = rolesRepository;
        }

        public async Task<Unit> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
        {
            var roleId= request.RoleId;
            
            var roleToDelete = await _rolesRepository.GetByIdAsync(roleId);

            if (roleToDelete == null)
            {
                throw new NotFoundException(nameof(Role), roleId);
            }
            roleToDelete.IsActive = false;
            await _rolesRepository.UpdateAsync(roleToDelete);
            return Unit.Value;
        }
    }
}
