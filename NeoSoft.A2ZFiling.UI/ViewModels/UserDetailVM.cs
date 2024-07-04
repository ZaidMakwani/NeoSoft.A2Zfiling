using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class UserDetailVM
    {
        public int UserDetailId { get; set; }

        [Required(ErrorMessage ="Company Name is Required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage ="Company Address is Required")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage ="Select the Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }


		[Required(ErrorMessage = "Select the Industry")]
		[ForeignKey("Industry")]
        public int IndustryId { get; set; }

		[Required(ErrorMessage = "Select the State")]
		[ForeignKey("State")]
        public int StateId { get; set; }

		[Required(ErrorMessage = "Select the City")]
		[ForeignKey("City")]
        public int CityId { get; set; }

		[Required(ErrorMessage = "Select the Municipal")]
		[ForeignKey("MunicipalCorp")]
        public int MunicipalId { get; set; }

        public bool? IsActive { get; set; }
		
		public List<int> DocumentMasterId { get; set; }

		[Required(ErrorMessage = "File is Required")]
		public List<IFormFile> FileName { get; set; }
        public List<string>? FileCollection { get; set; }



	}
}
   