using NeoSoft.A2Zfiling.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class MunicipalVM
    {
        public int MunicipalId { get; set; }
        public string MunicipalName { get; set; }
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pincode must be numeric.")]
        public string? Pincode { get; set; }
        public bool IsActive { get; set; }


        public int StateId { get; set; }
        public virtual State State { get; set; }
        public string? StateName { get; set; }
        public string? CityName { get; set; }
        public string? ZoneName { get; set; }

        public int? CityId { get; set; }
        public virtual City? City{ get; set; }
        public int ZoneId { get; set; }
        public virtual Zones Zones { get; set; }



    }
}
