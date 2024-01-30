using Business.Models;
using Dominio.DTO;
namespace Feedbapp.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request,EmailConfig emailConfig);
    }
}
