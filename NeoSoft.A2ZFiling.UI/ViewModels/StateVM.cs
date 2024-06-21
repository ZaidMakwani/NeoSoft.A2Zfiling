using NeoSoft.A2Zfiling.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class StateVM
    {
        public int StateId { get; set; }

        [Required]
        public string StateName { get; set; }

        [Required]
        public bool IsActive { get; set; }


        

        public virtual ICollection<City>? Cities { get; set; }
    }
}
