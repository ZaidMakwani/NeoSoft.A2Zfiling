using NeoSoft.A2Zfiling.Domain.Entities;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class CityVM
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public bool IsActive { get; set; }
        public int StateId { get; set; }
        public string? StateName { get; set; }
        public virtual State State { get; set; }
        public int ZoneId { get; set; }
        public string? ZoneName { get; set; }
        public virtual Zones Zones {  get; set; }  
 
        public virtual ICollection<MunicipalCorp> MunicipalCorporations { get; set; }


    }
}
