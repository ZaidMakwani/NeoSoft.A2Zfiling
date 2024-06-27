using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Filter;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    [CustomAuthorize]
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



        [HttpGet]
        public IActionResult GetAll()
        {
            Response<List<CompanyVM>> companyList = new Response<List<CompanyVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Company/GetAllCompanies/all").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                companyList = JsonConvert.DeserializeObject<Response<List<CompanyVM>>>(data);
            }

            return PartialView("_GetAllCompany",companyList.Data);
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
            if (string.IsNullOrEmpty(model.CompanyName))
            {
                return BadRequest("Please enter a valid Company name.");
            }

            if (string.IsNullOrEmpty(model.ShortName))
            {
                return BadRequest("Please enter a valid Short name.");
            }
            if ((model.ShortName.Any(char.IsDigit)) || (model.CompanyName.Any(char.IsDigit)))
            {
                return BadRequest(" Name cannot contain numbers.");
            }
            if (model.CompanyName.Length < 5 || model.CompanyName.Length > 50)
            {
                return BadRequest("Company Name must be between 5 and 50 characters.");
            }
            if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
            {
                return BadRequest("Company Name must be between 2 and 10 characters.");
            }
            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return BadRequest("Failed to create Company");
        }



        //-----------------------------------------------Update Company------------------------------------------------
        [HttpGet]
        public IActionResult Update(int id)
 {   
            Response<CompanyVM> company = new Response<CompanyVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/Company/GetCompaniesById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                company = JsonConvert.DeserializeObject<Response<CompanyVM>>(data);
            }

            return PartialView("_UpdateCompany",company.Data);
        }

        [HttpPost]
        public IActionResult Update(CompanyVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Company/Update/", content).Result;

            if (string.IsNullOrEmpty(model.CompanyName))
            {
                return BadRequest("Please enter a valid Company name.");
            }

            if (string.IsNullOrEmpty(model.ShortName))
            {
                return BadRequest("Please enter a valid Short name.");
            }
            if ((model.ShortName.Any(char.IsDigit)) || (model.CompanyName.Any(char.IsDigit)))
            {
                return BadRequest(" Name cannot contain numbers.");
            }
            if (model.CompanyName.Length < 5 || model.CompanyName.Length > 50)
            {
                return BadRequest("Company Name must be between 5 and 50 characters.");
            }
            if (model.ShortName.Length < 2 || model.ShortName.Length > 10)
            {
                return BadRequest("Company Name must be between 2 and 10 characters.");
            }
            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return BadRequest("Failed to update Company");
        }

        //-----------------------------------------------Delete Company------------------------------------------------
       
        public IActionResult Delete(int id)
        {
            Response<CompanyVM> company = new Response<CompanyVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/Company/Delete?Id={id}").Result;           
            return Ok();          
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
