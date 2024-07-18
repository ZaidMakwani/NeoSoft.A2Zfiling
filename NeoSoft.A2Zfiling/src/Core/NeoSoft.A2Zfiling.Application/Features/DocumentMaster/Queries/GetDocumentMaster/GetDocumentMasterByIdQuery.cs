using MediatR;
using NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetAllDocumentMasterQuery;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetDocumentMaster
{
    public class GetDocumentMasterByIdQuery:IRequest<Response<GetAllDocumentMasterQueryVM>>
    {
        public int DocumentMasterId { get; set; }  
    }
}
