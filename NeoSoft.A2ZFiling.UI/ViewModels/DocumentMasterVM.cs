using NeoSoft.A2Zfiling.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class DocumentMasterVM
    {
        public int DocumentMasterId { get; set; }
        [Required(ErrorMessage = "Enter the Document Name")]
        [StringLength(50, ErrorMessage = "Document Name cannot be longer than 50 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Document Name can only contain alphabets")]
        public string? DocumentName { get; set; }

        [Required(ErrorMessage = "Select a Document Format")]
        public string? DocumentFormat { get; set; }

        [Required(ErrorMessage = "Upload a Sample Format File")]
        public IFormFile? SampleFormatFile { get; set; }

        [Required(ErrorMessage = "Enter the Sample Format")]
        public string? SampleFormat { get; set; }

        [Required(ErrorMessage = "Specify whether the document is active")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Provide a list of Document Formats")]
        public List<string>? DocumentFormatList { get; set; }
        public List<string> FormatList = new List<string>() { "pdf", "png", "jpg", "jpeg" };
        public virtual ICollection<LicenseMaster>? LicenseMasters { get; set; }
        public virtual ICollection<LicenseDocument>? LicenseDocuments { get; set; }
    }
}
