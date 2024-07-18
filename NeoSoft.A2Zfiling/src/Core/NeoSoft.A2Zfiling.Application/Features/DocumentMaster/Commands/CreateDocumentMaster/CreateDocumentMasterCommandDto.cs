using Microsoft.AspNetCore.Http;
using NeoSoft.A2Zfiling.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Commands.CreateDocumentMaster
{
    public class CreateDocumentMasterCommandDto
    {
        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }
        public List<string> DocumentFormat { get; set; }
        public string SampleFormat { get; set; }
        public bool IsActive { get; set; }
      
    }
}
