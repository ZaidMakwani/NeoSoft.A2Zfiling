using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;


namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class LocationSettingsController : Controller
    {
        private readonly IZoneService _zoneService;
        private readonly IMunicipalService _municipalService;
        private readonly ICityService _cityService;
        public LocationSettingsController(IZoneService zoneService, IMunicipalService municipalService, ICityService cityService)
        {
            _zoneService = zoneService;
            _municipalService = municipalService;
            _cityService = cityService;


        }
        public async Task<IActionResult> Index()
        {
            var municipalities = await _municipalService.GetMunicipalAsync();
            var zones = await _zoneService.GetZoneAsync();
            var cities = await _cityService.GetCityAsync();

            var viewModel = new LocationSViewModel
            {
                
                Municipalities = municipalities,
                Zones = zones,
                Cities = cities
            };

            //ViewBag.TableOne = municipalities;
            //ViewBag.TableTwo = zones;
            //ViewBag.TableThree = cities;


            return PartialView("Index", viewModel);
        }

    }
}
