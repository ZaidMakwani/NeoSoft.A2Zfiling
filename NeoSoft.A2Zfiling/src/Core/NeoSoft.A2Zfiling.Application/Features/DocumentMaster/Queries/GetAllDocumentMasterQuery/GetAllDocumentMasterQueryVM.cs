using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.DocumentMaster.Queries.GetAllDocumentMasterQuery
{
    public class GetAllDocumentMasterQueryVM
    {

        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFormat { get; set; }
        public string SampleFormat { get; set; }
        public bool IsActive { get; set; }

    }
}
