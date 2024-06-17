using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class LicenseMasterController : Controller
    {
        private readonly ILogger<LicenseMasterController> _logger;
        private readonly ILicenceMasterService _licenseMasterService;
        private readonly ILicenseType _licenseType;
        private readonly ILicenseService _licenseService;
        private readonly IIndustryService _industryService;
        private readonly ICityService _cityService;
        private readonly IMunicipalService _municipalService;
        private readonly IZoneService _zoneService;
        
        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;

        public LicenseMasterController(IZoneService zoneService,IMunicipalService municipalService,ICityService cityService, IIndustryService industryService, ILicenseService licenseService,ILicenceMasterService licenseMasterService, ILicenseType licenseType,ILogger<LicenseMasterController> logger)
        {
            _licenseMasterService = licenseMasterService;
            _licenseType = licenseType;
            _logger = logger;
            _licenseService = licenseService;
            _industryService=industryService;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _cityService = cityService;
           _municipalService = municipalService;
            _zoneService = zoneService;
        }
        public async Task<IActionResult> Index()
        {
            var response= await _licenseMasterService.GetLicenseMasterAsync();
            //LicenseMasterVM license=new LicenseMasterVM()
            //{ 
            //    LicenseMasterId=response.
            //};
            return View(response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Response<List<StateVM>> stateList = new Response<List<StateVM>>();
            HttpResponseMessage response =  _client.GetAsync(_client.BaseAddress + "/State/GetAllStates/all").Result;
            
            string data = response.Content.ReadAsStringAsync().Result;
            stateList = JsonConvert.DeserializeObject<Response<List<StateVM>>>(data);

            var model = new LicenseMasterVM
            {
                VisibilityList = Enum.GetValues(typeof(Visibility)).Cast<Visibility>().Select(e => new SelectListItem
                {
                    Value = e.ToString(),
                    Text = e.ToString()
                }).ToList(),

                States=stateList.Data
                
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(LicenseMasterVM model) 
        {
            model.VisibilityList = Enum.GetValues(typeof(Visibility)).Cast<Visibility>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }).ToList();
            var response = await _licenseMasterService.CreateLicenseMaster(model);
            return RedirectToAction("Index","LicenseMaster");
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Fetch the list of states
            Response<List<StateVM>> stateList = new Response<List<StateVM>>();
            HttpResponseMessage responses = _client.GetAsync(_client.BaseAddress + "/State/GetAllStates/all").Result;
            string data = responses.Content.ReadAsStringAsync().Result;
            stateList = JsonConvert.DeserializeObject<Response<List<StateVM>>>(data);

            var response = await _licenseMasterService.GetLicenseMasterAsync();
            var license=response.FirstOrDefault(x=>x.LicenceMasterId== id);
            if (license!=null)
            {
                var model = new LicenseMasterVM
                {
                    LicenceMasterId = id,
                    LicenseId=license.LicenseId,
                    LicenseTypeId=license.LicenseTypeId,
                    VisibilityList= Enum.GetValues(typeof(Visibility)).Cast<Visibility>().Select(e => new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = e.ToString()
                    }).ToList(),
                    Visibilities=license.Visibilities,
                    CompanyId=license.CompanyId,
                    IndustryId=license.IndustryId,
                    ZoneId=license.ZoneId,
                    StateId=license.StateId,
                    CityId=license.CityId,
                    MunicipalId=license.MunicipalId,
                    Validity=license.Validity,
                    StandardRate=license.StandardRate,
                    StandardTAT=license.StandardTAT,
                    FastTrackRate=license.FastTrackRate,
                    FastTrackTAT=license.FastTrackTAT,
                    States = stateList.Data
                };
                return View(model);
            }
            else
            {
                return NotFound();
            }
           
        }
        [HttpPost]
        public async Task<IActionResult> Edit(LicenseMasterVM model)
        {
            var result = await _licenseMasterService.UpdateLicenseMasterAsync(model);
            
            return RedirectToAction("Index","LicenseMaster");
        }

      
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _licenseMasterService.DisableLicenseMasterAsync(id);

            return RedirectToAction("Index", "LicenseMaster");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLicenseType()
        {
            try
            {
                _logger.LogInformation("License Type Action Initiated");
                var response = await _licenseType.GetLicenseTypeAsync();
                _logger.LogInformation("License Type Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLicense()
        {
            try
            {
                _logger.LogInformation("GetAll License Action Initiated");

                var response = await _licenseService.GetLicenseAsync();
                _logger.LogInformation("GetAll License Action Completed");
                return Ok(response);
            }

            catch (Exception ex)
            {
                _logger.LogError("An error occurred whike getting all license");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllIndustry()
        {

            var response = _industryService.GetIndustryAsync();

            return Ok(response);
        }
        
        [HttpGet]
        public IActionResult GetAllCompany()
        {
            Response<List<CompanyVM>> companyList = new Response<List<CompanyVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Company/GetAllCompanies/all").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                companyList = JsonConvert.DeserializeObject<Response<List<CompanyVM>>>(data);
            }

            return Ok(companyList.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCityByState(int id)
        {
            try
            {
                _logger.LogInformation("City Action Initiated");
                var response = await _cityService.GetCityByStateAsync(id);
                _logger.LogInformation("City Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching city.");
                return StatusCode(500, "An error occurred while creating city.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMunicipalByCity(int id)
        {
            try
            {
                _logger.LogInformation("Municipal Action Initiated");
                var response = await _municipalService.GetMunicipalByCityAsync(id);
                _logger.LogInformation("Municipal Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching municipal.");
                return StatusCode(500, "An error occurred while fetching municipal.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllZone()
        {
            try
            {
                _logger.LogInformation("Zone Action Initiated");
                var response = await _zoneService.GetZoneAsync();
                _logger.LogInformation("Zone Action Completed");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating zone.");
                return StatusCode(500, "An error occurred while creating zone.");
            }
        }
        //[HttpGet]
        //public JsonResult GetCities(int stateId)
        //{
        //    var cities = _cascadingRepository.GetCities(stateId).Select(c => new { Value = c.StateId, Text = c.State.StateName }).ToList();
        //    return Json(cities);
        //}

        //[HttpGet]
        //public JsonResult GetMunicipalities(int cityId)
        //{
        //    var municipalities = _cascadingRepository.GetMunicipalities(cityId).Select(m => new { Value = m.MunicipalId, Text = m.MunicipalName }).ToList();
        //    return Json(municipalities);
        //}

    }
}
