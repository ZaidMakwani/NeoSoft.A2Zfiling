using MediatR;
using NeoSoft.A2Zfiling.Application.Responses;

namespace NeoSoft.A2Zfiling.Application.Features.Login.Command
{
    public class LoginCommand:IRequest<Response<LoginDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsRemember {  get; set; }
        //public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
