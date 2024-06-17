using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class LicenseMaster
    {
        // Dropdown for License selection
        [Display(Name = "Select License")]
        public int SelectLicense { get; set; }
        public IEnumerable<SelectListItem> LicenseOptions { get; set; }

        // Dropdown for License Classification selection
        [Display(Name = "Select License Classification")]
        public int SelectLicenseClassification { get; set; }
        public IEnumerable<SelectListItem> ClassificationOptions { get; set; }

        // Dropdown for Offline/Online/Semi-Online selection
        [Display(Name = "Is Offline / Online / Semi-Online?")]
        public string OfflineOnlineSemiOnline { get; set; }
        public IEnumerable<SelectListItem> OfflineOnlineOptions { get; set; }

        // Toggle for lifetime validity
        [Display(Name = "Is Valid for Lifetime?")]
        public bool IsValidForLifetime { get; set; }

        // Multi-select dropdown for Region
        [Display(Name = "Select Region")]
        public IEnumerable<int> SelectRegion { get; set; }
        public IEnumerable<SelectListItem> RegionOptions { get; set; }

        // Multi-select dropdown for State
        [Display(Name = "Select State")]
        public IEnumerable<int> SelectState { get; set; }
        public IEnumerable<SelectListItem> StateOptions { get; set; }

        // Multi-select dropdown for City
        [Display(Name = "Select City")]
        public IEnumerable<int> SelectCity { get; set; }
        public IEnumerable<SelectListItem> CityOptions { get; set; }

        // Multi-select dropdown for Municipal Corporation
        [Display(Name = "Select Municipal Corporation")]
        public IEnumerable<int> SelectMunicipalCorporation { get; set; }
        public IEnumerable<SelectListItem> MunicipalCorporationOptions { get; set; }

        // Multi-select dropdown for Industry Type
        [Display(Name = "Select Industry Type")]
        public IEnumerable<int> SelectIndustryType { get; set; }
        public IEnumerable<SelectListItem> IndustryTypeOptions { get; set; }

        // Multi-select dropdown for Company Type
        [Display(Name = "Select Company Type")]
        public IEnumerable<int> SelectCompanyType { get; set; }
        public IEnumerable<SelectListItem> CompanyTypeOptions { get; set; }

        // Checkbox for Document Types
        [Display(Name = "Select Document Types")]
        public IEnumerable<string> SelectDocumentTypes { get; set; }
        public IEnumerable<SelectListItem> DocumentTypeOptions { get; set; }

        // Radio buttons for Workflow Type
        [Display(Name = "Workflow Type")]
        public string WorkflowType { get; set; }

        // Textbox for Standard Pricing
        [Display(Name = "Standard Pricing (INR)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a valid price")]
        public decimal StandardPricing { get; set; }
    }
}
