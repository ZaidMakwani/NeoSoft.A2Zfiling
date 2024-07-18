using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.ViewModels;
using System.Net.Mail;
using System.Net;
using Twilio.Types;
using Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class ServiceRegistrationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string accountSid = "ACa217336b6f13ecd2ba825f26cdc9f952";
        private readonly string authToken = "dc1f7ba8dc168e8a6c086aa210a51fd6";
        private readonly string fromPhoneNumber = "+17178825643";

        public ServiceRegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            TempData["Service"] = "GST Registration";
            return View("Index");
        }

        public IActionResult FSSAIRegistration()
        {
            TempData["Service"] = "FSSAI Registration";
            return View("FSSAIRegistration");
        }

        public IActionResult CompanyRegistration()
        {
            TempData["Service"] = "Company Registration";
            return View("CompanyRegistration");
        }

        public IActionResult BuisnessSetupRegistration()
        {
            TempData["Service"] = "Buisness Setup Registration";
            return View("BusinessSetupRegistration");
        }
         
        [HttpPost]
        public IActionResult SendOtp(OtpRequest model)
        {

            if (!string.IsNullOrWhiteSpace(model.MobileNumber))
            {
                TwilioClient.Init(accountSid, authToken);
                string otp = GenerateOtp();
                SendOtp("+91"+model.MobileNumber, otp);
                ViewBag.Message = $"OTP sent to {model.MobileNumber}";

                TempData["OTP"] = otp;
                TempData["MobileNumber"] = model.MobileNumber;
                if(model.Otp != null)
                {
                    TempData["Message"] = "OTP sent again. Please Try Again!";
                }


                return PartialView("_OtpInputPartial", model);
            }
            else
            {
                ViewBag.Message = "Invalid Mobile number";
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult VerifyOtp(OtpResponse model)
        {
            string storedOtp = TempData["OTP"] as string;
            string storedMobileNumber = TempData["MobileNumber"] as string;

            if (model.Otp == storedOtp)
            {
                TempData["Message"] = "OTP verified successfully!";
                return RedirectToActionPermanent("Create", "UserDetail");
            }
            else if (storedOtp == "otp")
            {
                TempData["Message"] = "OTP sent again. Please Try Again!";
                return PartialView("_OtpInputPartial");
            }
            else
            {
                
                ViewBag.Message = "Invalid OTP. Please try Again!";
                var otpRequestModel = new OtpRequest
                {
                    MobileNumber = storedMobileNumber
                };
                return PartialView("_OtpInputPartial",otpRequestModel);
            }
            
        }


        private string GenerateOtp()
        {
            // Generate a 6-digit OTP
            Random rand = new Random();
            int otp = rand.Next(100000, 999999);
            return otp.ToString();
        }

        private void SendOtp(string toPhoneNumber, string otp)
        {
            MessageResource.Create(
                body: $"Your OTP is {otp}",
                from: new PhoneNumber(fromPhoneNumber),
                to: new PhoneNumber(toPhoneNumber)
            );
        }

    }
}
