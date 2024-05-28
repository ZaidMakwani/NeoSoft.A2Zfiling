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

namespace NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal
{
    public class UpdateMunicipalCommandHandler : IRequestHandler<UpdateMunicipalCommand, Response<MunicipalDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepository;

        public UpdateMunicipalCommandHandler(IAsyncRepository<MunicipalCorp> municipalRepository, IMapper mapper)
        {
            _municipalRepository = municipalRepository;
            _mapper = mapper;
        }

        public async Task<Response<MunicipalDto>> Handle(UpdateMunicipalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var municipalToUpdate = await _municipalRepository.GetByIdAsync(request.MunicipalId);
                if (municipalToUpdate == null)
                {

                    throw new NotFoundException("Not Found", request.MunicipalId);
                }

                _mapper.Map(request, municipalToUpdate);


                await _municipalRepository.UpdateAsync(municipalToUpdate);
                var updateMunicipal = _mapper.Map<MunicipalDto>(municipalToUpdate);

                return new Response<MunicipalDto>(updateMunicipal, "Municipal Updated Successfully");
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
