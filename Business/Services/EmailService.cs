using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Business.Models;
using Dominio.DTO;

namespace Feedbapp.Services
{
    public class EmailService : IEmailService
    {
        public EmailService( )
        { 
        }
        public void SendEmail(EmailDTO request,EmailConfig emailConfig)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailConfig.UserName));
            email.To.Add(MailboxAddress.Parse(request.Address));
            email.Subject = request.Topic;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Body
            };
            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;
            smtp.Connect(emailConfig.Host,Convert.ToInt32(emailConfig.Port),SecureSocketOptions.Auto);
            smtp.Authenticate(emailConfig.UserName, emailConfig.Password);
            smtp.Send(email);
            
            smtp.Disconnect(true);
        }
    }
}
