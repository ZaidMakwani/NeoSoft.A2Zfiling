using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Application.Features.Events.Commands.DeleteRoles;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.DeleteMunicipal
{
    public class DeleteMunicipalCommandHandler : IRequestHandler<DeleteMunicipalCommand>
    {
        private readonly IAsyncRepository<MunicipalCorp> _municipalRepository;

        public DeleteMunicipalCommandHandler(IAsyncRepository<MunicipalCorp> municipalRepository)
        {
            _municipalRepository = municipalRepository;
        }

        public async Task<Unit> Handle(DeleteMunicipalCommand request, CancellationToken cancellationToken)
        {
            var municipalId = request.MunicipalId;

            var municipalToDelete = await _municipalRepository.GetByIdAsync(municipalId);

            if (municipalToDelete == null)
            {
                throw new NotFoundException(nameof(Role), municipalId);
            }
            municipalToDelete.IsActive = false;
            await _municipalRepository.UpdateAsync(municipalToDelete);
            return Unit.Value;
        }
    }
}
