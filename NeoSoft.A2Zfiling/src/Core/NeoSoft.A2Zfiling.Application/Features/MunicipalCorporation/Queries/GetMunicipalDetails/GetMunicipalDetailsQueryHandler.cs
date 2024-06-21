using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleDetails;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails
{
    public class GetMunicipalDetailsQueryHandler : IRequestHandler<GetMunicipalDetailsQuery, Response<GetMunicipalDto>>
    {
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepository;

        private readonly IMapper _mapper;

        
        public GetMunicipalDetailsQueryHandler(IMapper mapper, IAsyncRepository<MunicipalCorp> municipalRepository)
        {
            _mapper = mapper;
            _municipalRepository = municipalRepository;

        }

        public async Task<Response<GetMunicipalDto>> Handle(GetMunicipalDetailsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var id = request.MunicipalId;
                var @municipal = await _municipalRepository.GetByIdAsync(id);
                var municipalDetailDto = _mapper.Map<GetMunicipalDto>(@municipal);

                //var municipals = await _municipalRepository.GetByIdAsync(@municipal.MunicipalId);

                if (municipalDetailDto == null)
                {
                    throw new NotFoundException(nameof(Role), @municipal.MunicipalId);
                }
                var response = new Response<GetMunicipalDto>(municipalDetailDto);
                if (@municipal.IsActive)
                {
                    return response;
                }
                else
                {
                    return new Response<GetMunicipalDto> { Message = "Not Found" };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
