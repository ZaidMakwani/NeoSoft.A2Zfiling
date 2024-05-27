using NeoSoft.A2Zfiling.Application.Responses;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using Newtonsoft.Json;

namespace NeoSoft.A2ZFiling.UI.services
{
    public class IndustryService : IIndustryService
    {
        Uri baseAddress = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;
        private readonly ILogger<IndustryService> _logger;

        public IndustryService(ILogger<IndustryService> logger)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _logger = logger;
        }

        public HttpResponseMessage CreateIndustryAsync(IndustryVM model)
        {
            _logger.LogInformation("Create IndustryService Initiated");
            //var data = await _apiClient.PostAsync("Zone/", model);

            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Industry/Create", content).Result;

            _logger.LogInformation("Create IndustryService Completed");
            return response;
        }

        //public async Task<ZoneVM> DeleteIndustryAsync(int id)
        //{
        //    _logger.LogInformation("Delete ZoneService Initiated");

        //    var getById = await _apiClient.GetByIdAsync($"Zone/id?id={id}");
        //    if (getById == null)
        //    {
        //        _logger.LogError("Zone not found.");
        //        return null;
        //    }
        //    var zone = getById.Data;
        //    zone.IsActive = false;
        //    var updatedata = await _apiClient.PutAsync("Zone/id", zone);
        //    _logger.LogInformation("Delete ZoneService Completed");

        //    return updatedata.Data;
        //}

        //public async Task<ZoneVM> GetByIdAsync(int id)
        //{
        //    _logger.LogInformation("GetById ZoneService Initiated");
        //    var zones = await _apiClient.GetByIdAsync($"Zone/id?id={id}");
        //    _logger.LogInformation("GetById ZoneService Completed");
        //    return zones.Data;

        //}


        public IEnumerable<IndustryVM> GetIndustryAsync()
        {
            _logger.LogInformation("GetAll IndustryService Initiated");
            Response<List<IndustryVM>> industryList = new Response<List<IndustryVM>>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Industry/GetAllIndustries/all").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                industryList = JsonConvert.DeserializeObject<Response<List<IndustryVM>>>(data);
            }
            _logger.LogInformation("GetAll IndustryService Completed");
            return industryList.Data;
        }



        //public async Task<ZoneVM> GetIndustryByNameAsync(string zoneName)
        //{
        //    _logger.LogInformation($"GetZoneByNameAsync ZoneService Initiated for zoneName: {zoneName}");

        //    var zones = await _apiClient.GetAllAsync($"Zone/all?zoneName={zoneName}");

        //    if (zones == null || zones.Data == null || !zones.Data.Any())
        //    {
        //        _logger.LogError($"Zone with name '{zoneName}' not found.");
        //        return null;
        //    }

        //    var zone = zones.Data.FirstOrDefault();

        //    _logger.LogInformation($"GetZoneByNameAsync ZoneService Completed for zoneName: {zoneName}");
        //    return zone;
        //}

        //public async Task<ZoneVM> UpdateIndustryAsync(ZoneVM role)
        //{
        //    _logger.LogInformation("UpdateZone ZoneService Initiated");
        //    var zones = await _apiClient.PutAsync("Zone/id", role);
        //    _logger.LogInformation("UpdateZone ZoneService Completed");
        //    return zones.Data;
        //}
    }
}
