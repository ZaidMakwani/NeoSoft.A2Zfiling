using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using NeosoftA2Zfilings.Views.ViewModels;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeosoftA2Zfilings.Views.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class AccountController : Controller
    {

        Uri baseAddres = new Uri("https://localhost:5000/api");
        private readonly HttpClient _client;
        private readonly IDNTCaptchaValidatorService _captchaValidator;
        private readonly IRegisterService _registerService;
        private readonly ILoginService _loginService;
        private readonly ILogger<AccountController> _logger;
        
        public AccountController(IRegisterService registerService, ILogger<AccountController> logger,
            IDNTCaptchaValidatorService captchaValidator,ILoginService loginService)
        {
            _registerService = registerService;
            _logger = logger;
            _captchaValidator = captchaValidator;
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();  
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (!_captchaValidator.HasRequestValidCaptchaEntry())
                {
                    TempData["captchaError"] = "Please enter valid security key";
                    return View(model);
                }

                _logger.LogInformation("Login is initiated");
                model.Expiration=DateTime.Now;
                model.RefreshToken = " ";
                model.Token = " ";
                var response= await _loginService.LoginAsync(model);

                return RedirectToAction("Index", "Home");
            }

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
