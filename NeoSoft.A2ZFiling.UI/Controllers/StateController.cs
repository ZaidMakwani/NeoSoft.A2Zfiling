﻿using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Responces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class StateController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;

        public StateController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult ReadAll()
        {
            Response<List<StateVM>> stateList = new Response<List<StateVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/State/GetAllStates/all").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                stateList = JsonConvert.DeserializeObject<Response<List<StateVM>>>(data);
            }

            return View(stateList.Data);
        }

        [HttpGet]
        public IActionResult Create()        
        {
            return PartialView("_CreateState");
        }

        [HttpPost]
        public async Task<IActionResult> Create(StateVM state)
        {
            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(state);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync(_client.BaseAddress + "/State/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Response<CreateStateVm>>(responseData);
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

            return View(state);
        }

        public IActionResult Update(int id)
        {
            Response<StateVM> state = new Response<StateVM>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + $"/State/GetStateById?Id={id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                state = JsonConvert.DeserializeObject<Response<StateVM>>(data);
            }

            return View("_UpdateState", state.Data);
        }

        [HttpPost]
        public IActionResult Update(StateVM model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/State/Update/", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return View();
        }



        //-----------------------------------------------Delete State------------------------------------------------

        public IActionResult Delete(int id)
        {
            Response<StateVM> industry = new Response<StateVM>();
            HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + $"/State/Delete?Id={id}").Result;
            return RedirectToActionPermanent("ReadAll");
        }




    }
}
