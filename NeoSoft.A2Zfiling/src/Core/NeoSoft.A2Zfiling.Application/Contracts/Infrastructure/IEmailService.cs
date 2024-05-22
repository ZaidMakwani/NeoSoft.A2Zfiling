using NeoSoft.A2Zfiling.Application.Models.Mail;
using System.Threading.Tasks;

namespace NeoSoft.A2Zfiling.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
