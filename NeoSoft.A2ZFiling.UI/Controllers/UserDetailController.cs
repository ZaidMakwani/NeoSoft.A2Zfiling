using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class UserDetailController : Controller
    {
		private readonly ILogger<UserDetailController> _logger;
		private readonly IIndustryService _industryService;
		private readonly ICityService _cityService;
		private readonly IStateService _stateService;
		private readonly IMunicipalService _municipalService;


		public UserDetailController(ILogger<UserDetailController> logger,IIndustryService industryService,
			ICityService cityService, IStateService stateService,IMunicipalService municipalService)
		{			
			_logger = logger;
			_industryService = industryService;
			_cityService = cityService;
			_stateService = stateService;
			_municipalService = municipalService;
		}
	

        public  async Task<IActionResult> Create()
        {
			
			var industry =  _industryService.GetIndustryAsync();
			ViewBag.Industries = new SelectList(industry, "IndustryId", "IndustryName");
			var city =await _cityService.GetCityAsync();
			ViewBag.Cities = new SelectList(city, "CityId", "CityName");
			var state = await _stateService.GetStateAsync();
			ViewBag.States = new SelectList(state, "StateId", "StateName");
			var municipal = await _municipalService.GetMunicipalAsync();
			ViewBag.Municipalies = new SelectList(municipal, "MunicipalId", "MunicipalName");
			return View();
        }
    }
}
