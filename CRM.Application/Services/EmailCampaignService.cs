using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CRM.Application.Services
{
    public class EmailCampaignService
    {
        private readonly SmtpClient _smtpClient;
        private readonly string _fromEmail;

        public EmailCampaignService(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _fromEmail = configuration["Smtp:FromEmail"];
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var mailMessage = new MailMessage(_fromEmail, to, subject, body);
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log or handle exception
                Console.WriteLine($"Failed to send email to {to}: {ex.Message}");
                throw;
            }
        }

        public async Task SendBulkEmailAsync(IEnumerable<string> recipients, string subject, string body)
        {
            foreach (var recipient in recipients)
            {
                await SendEmailAsync(recipient, subject, body);
            }
        }
    }
}
