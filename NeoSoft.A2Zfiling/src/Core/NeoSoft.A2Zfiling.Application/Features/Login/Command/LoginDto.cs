using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Features.Login.Command
{
    public class LoginDto
    {
        public LoginDto() { }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRemember { get; set; }
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? Expiration {  get; set; }

    }
}
