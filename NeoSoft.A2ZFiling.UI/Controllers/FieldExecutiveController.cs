using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeoSoft.A2ZFiling.UI.Services;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Controllers
{
    public class FieldExecutiveController : Controller
    {
        private readonly UserInfoService _userInfoService;
        private readonly MyProfileService _profileService;
        public FieldExecutiveController(UserInfoService userInfoService, MyProfileService myProfileService)
        {
            _profileService = myProfileService;
            _userInfoService = userInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var users = _userInfoService.GetUserIdsByRoleAsync("Vendor");

            // Initialize a list to store user details
            var userList = new List<AppUserVM>();

            // Loop through the user IDs and get user details
            foreach (var user in users.Result)
            {
                var userDetails = _profileService.GetAccountDetailsAsync(user.Id); // Adjust according to your service method
                userList.Add(userDetails.Result);
            }

            ViewBag.UserList = userList;
            return View();
        }
    }
}
