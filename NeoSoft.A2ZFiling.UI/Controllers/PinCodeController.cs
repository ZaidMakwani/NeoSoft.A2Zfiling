using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Responces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class PinCodeController : Controller
    {
        Uri baseAddres = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;
        public PinCodeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddres;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReadAll()
        {
            Response<List<PinCodeVM>> pinCodeList = new Response<List<PinCodeVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/PinCode/GetAllPinCode/all").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                pinCodeList = JsonConvert.DeserializeObject<Response<List<PinCodeVM>>>(data);
            }


            return View(pinCodeList.Data);
        }
        
        public IActionResult CreatePincode()
        {
            return PartialView("_CreatePinCode");
        }



        [HttpPost]
        public async Task<IActionResult> CreatePincode(CreatePinCodeVM pinCode)
        {
            if (ModelState.IsValid) 
            {
                string json = JsonConvert.SerializeObject(pinCode);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/PinCode/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<PinCodeVM>>(responseData);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ReadAll");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, result.Message);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error posting data to API");
                }
            }

            return View(pinCode);
        }


        public IActionResult Update(int id)
        {
            Response<PinCodeVM> pincode = new Response<PinCodeVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/PinCode/GetPinCodeById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                pincode = JsonConvert.DeserializeObject<Response<PinCodeVM>>(data);
            }

            return View("_UpdatePinCode",pincode.Data);
        }

        [HttpPost]
        public IActionResult Update(PinCodeVM model)        
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/PinCode/Update/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
               // return RedirectToAction("ReadAll");
            }

            return View();
        }



        //-----------------------------------------------Delete PinCode------------------------------------------------

        public IActionResult Delete(int id)
        {
            Response<PinCodeVM> pincode = new Response<PinCodeVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/PinCode/Delete?Id={id}").Result;
            return RedirectToActionPermanent("ReadAll");
        }



    }
}