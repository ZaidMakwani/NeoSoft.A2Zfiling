using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class CityViewModel
    {

        public int? CityId { get; set; }
        public string? CityName { get; set; }


        [Required(ErrorMessage = "Please choose a city")]
        public string? SelectedCity { get; set; }

        public IEnumerable<SelectListItem>? CityList { get; set; }


    }
}
