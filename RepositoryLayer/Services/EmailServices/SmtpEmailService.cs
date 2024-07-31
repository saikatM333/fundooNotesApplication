using RepositoryLayer.Interfaces.EmailAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services.EmailServices
{
    public  class SmtpEmailService : IemailServices
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public SmtpEmailService(SmtpClient smtpClient, string fromEmail)
        {
            _smtpClient = smtpClient;
            _fromEmail = fromEmail;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage(_fromEmail, to, subject, body);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
