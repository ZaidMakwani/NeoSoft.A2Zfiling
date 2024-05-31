using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument
{
    public class CreateDocumentDto
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public bool IsActive { get; set; }


    }
}
