using MediatR;
using Microsoft.AspNetCore.Http;
using NeoSoft.A2Zfiling.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.UpdateDocumentMaster
{
    public class UpdateDocumentMasterCommand:IRequest<Response<UpdateDocumentMasterCommandDto>>
    {
        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }
        public List<string> DocumentFormat { get; set; }
        public IFormFile SampleFormat { get; set; }
        public bool IsActive { get; set; }
    }
}
