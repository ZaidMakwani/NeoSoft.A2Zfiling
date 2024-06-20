using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class LCController : Controller
    {
        private readonly IZoneService _zoneService;
        private readonly IMunicipalService _municipalService;
        private readonly ICityService _cityService;

        public LCController(IZoneService zoneService, IMunicipalService municipalService, ICityService cityService)
        {
            _zoneService = zoneService;
            _municipalService = municipalService;
            _cityService = cityService;
        }

        public async Task<IActionResult> LoadMunicipalPartial()
        {
            var municipalities = await _municipalService.GetMunicipalAsync();
            return PartialView("_Municipal", municipalities);
        }

        public async Task<IActionResult> LoadZonesPartial()
        {
            var zones = await _zoneService.GetZoneAsync();
            return PartialView("_Zones", zones);
        }

        public async Task<IActionResult> LoadCitiesPartial()
        {
            var cities = await _cityService.GetCityAsync();
            return PartialView("_CityPartialView", cities);
        }
    }
}
