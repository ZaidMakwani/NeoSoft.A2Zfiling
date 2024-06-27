using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class LocationTrackController : Controller
    {
        // GET: /LocationTrack/LocationTrackView
        public IActionResult LocationTrackView()
        {
            var viewModel = new CityViewModel();
            // Populate the dropdown list with cities
            viewModel.CityList = GetCitySelectList();

            return View(viewModel);
        }

        // GET: /LocationTrack/SelectCity
        public IActionResult SelectCity()
        {
            var cityViewModels = GetCityViewModels(); // Method to populate cityViewModels

            return View(cityViewModels);
        }


        // POST: /LocationTrack/SubmitCity
        [HttpPost]
        public IActionResult SubmitCity(CityViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["Message"] = $"You are in {model.SelectedCity}";
                return RedirectToAction("SelectCity");
            }

            // If ModelState is not valid, reload the LocationTrackView with validation errors
            model.CityList = GetCitySelectList(); // Reload city list
            return View("LocationTrackView", model);
        }

       
        private IEnumerable<CityViewModel> GetCityViewModels()
        {
            // Simulated data, replace with actual data retrieval logic
            var cities = new List<CityViewModel>
            {
                new CityViewModel { CityId = 1, CityName = "New York" },
                new CityViewModel { CityId = 2, CityName = "Los Angeles" },
                new CityViewModel { CityId = 3, CityName = "Chicago" },
                new CityViewModel { CityId = 4, CityName = "San Francisco" }
                // Add more cities as needed
            };

            return cities;
        }

        private SelectList GetCitySelectList()
        {
            return new SelectList(new[]
            {
                new SelectListItem { Value = "New York", Text = "New York" },
                new SelectListItem { Value = "Los Angeles", Text = "Los Angeles" },
                new SelectListItem { Value = "Chicago", Text = "Chicago" },
                new SelectListItem { Value = "San Francisco", Text = "San Francisco" }
                // Add more cities as needed
            }, "Value", "Text");
        }
    }
}
