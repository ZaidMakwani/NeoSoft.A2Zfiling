using MediatR;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Exceptions;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.License_Master.Commands.Delete
{
    public class DeleteLicenseMasterCommandHandler :IRequestHandler<DeleteLicenseMasterCommand>
    {
        private readonly IAsyncRepository<LicenseMaster> _licenseRepository;
        public DeleteLicenseMasterCommandHandler(IAsyncRepository<LicenseMaster> licenseRepository) 
        {
            _licenseRepository = licenseRepository;
        }  
        public async Task<Unit> Handle(DeleteLicenseMasterCommand command, CancellationToken cancellationToken) 
        {
            var licenseMasterId=command.LicenseMasterId;
            var licenses=_licenseRepository.ListAllAsync().Result.FirstOrDefault(x=>x.LicenceMasterId==licenseMasterId);
            if (licenses!=null)
            {
                licenses.IsActive = false;
                licenses.LastModifiedDate= DateTime.Now;
                await _licenseRepository.UpdateAsync(licenses);
                return Unit.Value;
            }
            else 
            {
                throw new NotFoundException(nameof(LicenseMaster), licenseMasterId);
            }
                
        }
    }
}
