using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.DeleteMunicipal
{
    public class DeleteMunicipalCommand:IRequest
    {
        public int MunicipalId { get; set; }
    }
}
