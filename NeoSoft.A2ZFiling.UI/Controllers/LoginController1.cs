using Microsoft.AspNetCore.Mvc;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class LoginController1 : Controller
    {
        Uri baseAddres = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;

        public LoginController1()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddres;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
