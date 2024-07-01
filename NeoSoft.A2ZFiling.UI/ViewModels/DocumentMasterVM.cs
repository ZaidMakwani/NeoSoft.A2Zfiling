using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class DocumentMasterVM
    {
        public int DocumentMasterId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentFormat { get; set; }
        public IFormFile SampleFormatFile { get; set; }
       
        public string SampleFormat { get; set; }
        public bool IsActive { get; set; }
        public List<string> DocumentFormatList { get; set; }
        public virtual ICollection<LicenseMaster> LicenseMasters { get; set; }
        public virtual ICollection<LicenseDocument> LicenseDocuments { get; set; }
    }
}
