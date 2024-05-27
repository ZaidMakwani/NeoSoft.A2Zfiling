using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class CompanyController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;

        public CompanyController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Response<List<CompanyVM>> companyList = new Response<List<CompanyVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress+ "/Company/GetAllCompanies/all").Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                companyList = JsonConvert.DeserializeObject<Response<List<CompanyVM>>>(data);
            }

            return View(companyList.Data);
        }

        //--------------------------------------------------Create Company--------------------------------------
        public IActionResult Create()
        {            
             
            return PartialView("_CreateCompany");
        }

        [HttpPost]
        public IActionResult Create(CompanyVM model)
        {
            string data = JsonConvert.SerializeObject(model); 
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Company/Create",content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



        //-----------------------------------------------Update Company------------------------------------------------
        public IActionResult Update(int id)
        {   
            Response<CompanyVM> company = new Response<CompanyVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Company/GetCompaniesById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                company = JsonConvert.DeserializeObject<Response<CompanyVM>>(data);
            }

            return View(company.Data);
        }

        [HttpPost]
        public IActionResult Update(CompanyVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Company/Update/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //-----------------------------------------------Delete Company------------------------------------------------
        
        public IActionResult Delete(int id)
        {
            Response<CompanyVM> company = new Response<CompanyVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Company/Delete?Id={id}").Result;           
            return RedirectToAction("Index");          
        }

        //[HttpPost]
        //public IActionResult Delete(CompanyVM model)
        //{
        //    string data = JsonConvert.SerializeObject(model);
        //    StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Company/Update/", content).Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}
    }
}
