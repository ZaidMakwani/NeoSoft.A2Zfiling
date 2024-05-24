using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles
{
    public class UpdateRolesCommand:IRequest<Response<RolesDto>>
    {
       
        public int RoleId { get; set;}
        public string RoleName { get; set;}
        public bool IsActive { get; set;}
      
        public DateTime LastModifiedDate { get; set;}=DateTime.Now;
    }
}
