using NeoSoft.A2Zfiling.Domain.Entities;
using System.Security.Policy;

namespace NeoSoft.A2ZFiling.UI.ViewModels
{
    public class LocationSViewModel
    {

        public IEnumerable<MunicipalVM> Municipalities { get; set; }
        public IEnumerable<ZoneVM> Zones { get; set; }
        public IEnumerable<CityVM> Cities { get; set; }

    }
}
