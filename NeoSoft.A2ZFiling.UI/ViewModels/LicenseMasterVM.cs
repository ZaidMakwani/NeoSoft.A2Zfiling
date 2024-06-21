using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class LicenseMasterVM
    {
        public int LicenceMasterId { get; set; }

        [Required(ErrorMessage ="Select License")]
        public int LicenseId { get; set; }

        public virtual License License { get; set; }

        [Required(ErrorMessage ="Select License Classification")]
        public int LicenseTypeId { get; set; }

        public virtual LicenseType LicenseType { get; set; }

        [MaxLength(50)]
     
        [Display(Name = "License Name")]
        public string? LicenseName { get; set; }

        [MaxLength(50)]
        [Display(Name = "Classification")]
        public string? Classification { get; set; }

        
        [Required(ErrorMessage ="Select option")]
        [Display(Name = "Visibilities")]
        public Visibility Visibilities { get; set; }

        [Required(ErrorMessage ="Select Validity")]
        [Display(Name = "Validity")]
        public bool Validity { get; set; }

        [Required(ErrorMessage ="Select Industry")]
        public int IndustryId { get; set; }

       
        [MaxLength(100)]
        [Display(Name = "Industry Type")]
        public string IndustryType { get; set; }

        [Required(ErrorMessage ="Select Company")]
        public int CompanyId { get; set; }

        [MaxLength(100)]
        [Display(Name = "Company Type")]
        public string CompanyType { get; set; }

        [Required(ErrorMessage ="Select State")]
       
        public int StateId { get; set; }

       
      
        
        public string StateName { get; set; }

        [Required(ErrorMessage ="Select Zone")]
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }

        [Required(ErrorMessage ="Select City")]
        public int CityId { get; set; }

        public string CityName { get; set; }

        [Required(ErrorMessage ="Select Municipal")]
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }

        [Required(ErrorMessage ="Select one option")]
        [Display(Name = "Workflow Type")]
        public string WorkflowType { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Standard Rate must be a number.")]
        [MaxLength(20)]
        [Display(Name = "Standard Rate")]
        public string StandardRate { get; set; }

        [Required(ErrorMessage = "Standard TAT is required.")]
        [MaxLength(20)]
        [Display(Name = "Standard TAT")]
        public string StandardTAT { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Fast Track Rate must be a number.")]
        [MaxLength(20)]
        [Display(Name = "Fast Track Rate")]
        public string FastTrackRate { get; set; }

        [Required( ErrorMessage = "Fast Track TATis required.")]
        [MaxLength(20)]
        [Display(Name = "Fast Track TAT")]
        public string FastTrackTAT { get; set; }

        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public IEnumerable<SelectListItem> VisibilityList { get; set; }
        public List<StateVM> States { get; set; }
        public List<City> Cities { get; set; }
        public List<MunicipalCorp> Municipalities { get; set; }
    }
}
