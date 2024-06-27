using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
    public class IndustryController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;
        private readonly IIndustryService _industryService;

        public IndustryController(IIndustryService industryService)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _industryService = industryService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var response = _industryService.GetIndustryAsync();

            return View(response);
        }



        //--------------------------------------------------Create Industry--------------------------------------
        public IActionResult Create()
        {

            return PartialView("_CreateIndustry");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(IndustryVM model)
        {
            if (string.IsNullOrEmpty(model.IndustryName))
            {
                return BadRequest("Please enter a valid Industry name.");
            }

            if (string.IsNullOrEmpty(model.ShortName))
            {
                return BadRequest("Please enter a valid Short name.");
            }
            if( (model.ShortName.Any(char.IsDigit)) || (model.IndustryName.Any(char.IsDigit)))
            {
                return BadRequest(" Name cannot contain numbers.");
            }
            if (model.IndustryName.Length < 5 || model.IndustryName.Length > 50)
            {
                return BadRequest("Industry Name must be between 5 and 50 characters.");
            }
            if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
            {
                return BadRequest("Industry Name must be between 2 and 10 characters.");
            }
            var existingIndustry = ( _industryService.GetIndustryAsync()).Where(x => x.IndustryName.ToLower() == model.IndustryName.ToLower() || x.ShortName.ToLower() == model.ShortName.ToLower()).FirstOrDefault();
            if (existingIndustry != null)
            {
                return BadRequest("Industry with this name already exists.");
            }
            var response = _industryService.CreateIndustryAsync(model);


            if (response.IsSuccessStatusCode)
            {
               // return PartialView("_GetAllIndustry");
                return Ok();
            }

            return BadRequest("Failed to create Industry");
        }



        //-----------------------------------------------Update Industry------------------------------------------------
        public IActionResult Update(int id )
        {
            Response<IndustryVM> industry = new Response<IndustryVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Industry/GetIndustriesById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                industry = JsonConvert.DeserializeObject<Response<IndustryVM>>(data);
            }

            return PartialView("_UpdateIndustry", industry.Data);
        }

        [HttpPost]
        public IActionResult Update(IndustryVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Industry/Update/", content).Result;

            if (string.IsNullOrEmpty(model.IndustryName))
            {
                return BadRequest("Please enter a valid Industry name.");
            }

            if (string.IsNullOrEmpty(model.ShortName))
            {
                return BadRequest("Please enter a valid Short name.");
            }
            if ((model.ShortName.Any(char.IsDigit)) || (model.IndustryName.Any(char.IsDigit)))
            {
                return BadRequest(" Name cannot contain numbers.");
            }
            if (model.IndustryName.Length < 5 || model.IndustryName.Length > 50)
            {
                return BadRequest("Industry Name must be between 5 and 50 characters.");
            }
            if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
            {
                return BadRequest("Industry Name must be between 2 and 10 characters.");
            }
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return View();
        }



        //-----------------------------------------------Delete Industry------------------------------------------------

        public IActionResult Delete(int id)
        {
            Response<IndustryVM> industry = new Response<IndustryVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Industry/Delete?Id={id}").Result;
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _industryService.GetIndustryAsync();
            return PartialView("_GetAllIndustry",response);
            //return View(response);
        }

    }
}
