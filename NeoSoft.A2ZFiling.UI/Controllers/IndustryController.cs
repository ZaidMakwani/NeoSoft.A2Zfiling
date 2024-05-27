using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
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
;

            //Response<List<IndustryVM>> industryList = new Response<List<IndustryVM>>();
            //HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Industry/GetAllIndustries/all").Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    string data = response.Content.ReadAsStringAsync().Result;
            //    industryList = JsonConvert.DeserializeObject<Response<List<IndustryVM>>>(data);
            //}

            //return View(industryList.Data);

            return View(response);
        }



        //--------------------------------------------------Create Industry--------------------------------------
        public IActionResult Create()
        {

            return PartialView("_CreateIndustry");
        }

        [HttpPost]
        public IActionResult Create(IndustryVM model)
        {
            var response = _industryService.CreateIndustryAsync(model);

            //string data = JsonConvert.SerializeObject(model);
            //StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            //HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Industry/Create", content).Result;

            if (response.IsSuccessStatusCode)
            {
                //return RedirectToAction("Index");
                return Ok();
            }

            return View();
        }



        //-----------------------------------------------Update Industry------------------------------------------------
        public IActionResult Update(int id)
        {
            Response<IndustryVM> industry = new Response<IndustryVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Industry/GetIndustriesById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                industry = JsonConvert.DeserializeObject<Response<IndustryVM>>(data);
            }

            return View(industry.Data);
        }

        [HttpPost]
        public IActionResult Update(IndustryVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Industry/Update/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        //-----------------------------------------------Delete Industry------------------------------------------------

        public IActionResult Delete(int id)
        {
            Response<IndustryVM> industry = new Response<IndustryVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Industry/Delete?Id={id}").Result;
            return RedirectToActionPermanent("Index");
        }

    }
}
