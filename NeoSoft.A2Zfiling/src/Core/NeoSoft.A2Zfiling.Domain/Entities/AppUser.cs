using Microsoft.AspNetCore.Identity;

namespace NeoSoft.A2Zfiling.Domain.Entities
{
    public class AppUser:IdentityUser
    {
       public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string PasswordCurr {  get; set; }
        //public string? Token { get; set; }
    }
}
