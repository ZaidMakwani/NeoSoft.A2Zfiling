using System.ComponentModel.DataAnnotations.Schema;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class UserDetailVM
    {
        public int UserDetailId { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Industry")]
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }
        public string StateName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public string CityName { get; set; }

        [ForeignKey("MunicipalCorp")]
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }

        public bool IsActive { get; set; }

        public List<int> DocumentMasterId { get; set; }

        public List<IFormFile> FileName { get; set; }

    }
}
   