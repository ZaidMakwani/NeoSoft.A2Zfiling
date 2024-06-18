using DNTCaptcha.Core;
using Microsoft.AspNetCore.Mvc;
using NeosoftA2Zfilings.Views.ViewModels;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;
using NeoSoft.A2Zfiling.Application.Contracts.Persistence;
using NeoSoft.A2Zfiling.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NeoSoft.A2Zfiling.Persistence.Repositories;
using Microsoft.AspNetCore.Hosting;

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
        //private readonly ITokenRepository _tokenRepository;

        public AccountController(IRegisterService registerService, ILogger<AccountController> logger,
            IDNTCaptchaValidatorService captchaValidator, ILoginService loginService /*,ITokenRepository tokenRepository*/)
        {
            _registerService = registerService;
            _logger = logger;
            _captchaValidator = captchaValidator;
            _loginService = loginService;
            //_tokenRepository = tokenRepository;

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Index()
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
                model.Expiration = DateTime.Now;
                model.RefreshToken = " ";
                //model.Token = " ";

                var response = await _loginService.LoginAsync(model);

                if (response != null)
                {
                    // Retrieve token value based on some criteria (e.g., user ID)
                    var token = response.Token;
                    
                    if (!string.IsNullOrEmpty(token))
                    {
                        HttpContext.Session.SetString("Token", token);

                        _logger.LogInformation("Token value: {TokenValue}", token);
                        return RedirectToAction("Index", "Home");
                        
                    }

                    // Handle token retrieval failure
                }

                // Handle login response being null
            }

            // Handle invalid ModelState
            return View(model);
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

            var webHostEnvironment = HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;

            string webRootPath = webHostEnvironment.WebRootPath;
            string uploadsFolder = Path.Combine(webRootPath, "images");

            // Check and create the directory if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            
            string uniqueFileName = null;

            if (model.ProfilePicture != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(fileStream);
                }
            }

            model.ProfileImagePath = uniqueFileName != null ? $"/images/{uniqueFileName}" : null;


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
        [HttpGet]
        public IActionResult GenerateNewCaptcha()
        {
            return PartialView("_CaptchaPartial");
        }
    }
}
