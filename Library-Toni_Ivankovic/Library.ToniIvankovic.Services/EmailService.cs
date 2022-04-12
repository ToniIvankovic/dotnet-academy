using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ToniIvankovic.Contracts.Dtos;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Library.ToniIvankovic.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }
        public async Task Send(string to, string subject, string body)
        {
            Console.WriteLine("Jel ispod mene key?\n");
            Console.WriteLine(_settings.Key, _settings.From);
            var sendGridClient = new SendGridClient(_settings.Key);
            var message = new SendGridMessage
            {
                Subject = subject,
                From = new EmailAddress(_settings.From),
                HtmlContent = body,
            };

            message.AddTo(new EmailAddress(to));
            var response = await sendGridClient.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Body.ReadAsStringAsync();
                throw new Exception($"Unable to send email: {error}");
            }
        }
    }
}
