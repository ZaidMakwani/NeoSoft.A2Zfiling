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

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList
{
    public class GetRolesListQueryHandler : IRequestHandler<GetRolesListQuery, Response<IEnumerable<RolesListVM>>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Role> _roleRepository;
    
        public GetRolesListQueryHandler(IAsyncRepository<Role> roleRepository, IMapper mapper) {
            _roleRepository = roleRepository;
            _mapper = mapper;
            
        }

        public async Task<Response<IEnumerable<RolesListVM>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            
            var allRoles = (await _roleRepository.ListAllAsync());
            var roles = _mapper.Map<IEnumerable<RolesListVM>>(allRoles.Where(x=>x.IsActive==true));
           
            return new Response<IEnumerable<RolesListVM>>(roles, "success");
        }
    }
}
