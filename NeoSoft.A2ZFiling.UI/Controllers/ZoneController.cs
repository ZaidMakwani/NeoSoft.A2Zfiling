using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class ZoneController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");

        private readonly HttpClient _httpClient;

        public ZoneController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult View()
        {
            Response<List<ZoneVM>> zoneVMs = new Response<List<ZoneVM>>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Zone/GetAllZone/all").Result;
            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                zoneVMs = JsonConvert.DeserializeObject<Response<List<ZoneVM>>>(data);

                
            }
            return View(zoneVMs.Data);
        }
    }
}
