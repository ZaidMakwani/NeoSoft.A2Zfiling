using AutoMapper;
using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal
{
    public class CreateMunicipalHandler : IRequestHandler<CreateMunicipalCommand, Response<CreateMunicipalDto>>

    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MunicipalCorp> _aysncRepository;
        

        public CreateMunicipalHandler(IMapper mapper, IAsyncRepository<MunicipalCorp> aysncRepository)
        {
            _mapper = mapper;
            
            _aysncRepository = aysncRepository;
        }
        public async Task<Response<CreateMunicipalDto>> Handle(CreateMunicipalCommand request, CancellationToken cancellationToken)
        {
                Response<CreateMunicipalDto> createMunicipalCommandResponse = null;

           

           
                var Municipal = new MunicipalCorp() { 
                    MunicipalName = request.MunicipalName,
                    IsActive = true,
                    CityId = (int)request.CityId,
                    ZoneId = request.ZoneId,
                    StateId= request.StateId,
                    Pincode = request.Pincode,
                };
                Municipal = await _aysncRepository.AddAsync(Municipal);
            var Mapper = _mapper.Map<CreateMunicipalDto>(Municipal);
                createMunicipalCommandResponse = new Response<CreateMunicipalDto>(Mapper, "success");
           

                return createMunicipalCommandResponse;
        }
    }
}
