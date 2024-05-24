using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;

namespace NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteRoles
{
    public class DeleteRolesCommand : IRequest
    {
        public int RoleId { get; set; }
    }
}
