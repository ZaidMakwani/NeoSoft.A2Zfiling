namespace NeoSoft.A2ZFiling.UI.Interfaces
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
