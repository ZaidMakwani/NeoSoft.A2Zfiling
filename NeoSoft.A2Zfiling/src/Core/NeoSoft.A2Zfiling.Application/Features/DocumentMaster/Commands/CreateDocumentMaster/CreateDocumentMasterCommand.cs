using MediatR;
using Microsoft.AspNetCore.Http;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.CreateDocumentMaster
{
    public class CreateDocumentMasterCommand:IRequest<Response<CreateDocumentMasterCommandDto>>
    {
        public string DocumentName { get; set; }
        public string DocumentFormat { get; set; }
        public string SampleFormat { get; set; }
        public bool IsActive { get; set; }
       
    }
}
