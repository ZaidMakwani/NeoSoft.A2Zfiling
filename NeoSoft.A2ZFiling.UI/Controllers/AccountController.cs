using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterService _registerService;
        private readonly ILogger<AccountController> _logger;
        public AccountController(IRegisterService registerService, ILogger<AccountController> logger)
        {
            _registerService = registerService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegisterVM model)
        {
            //string data = JsonConvert.SerializeObject(model);
            //StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            _logger.LogInformation("Registration is initiated");
            var response = await _registerService.RegisterAsync(model);
            if (response != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }
    }
}
