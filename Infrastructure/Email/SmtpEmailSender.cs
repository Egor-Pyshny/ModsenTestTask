using Domain.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Infrastructure.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            string userName = "mailman21378@gmail.com";

            var emailClient = new SmtpClient(
                host: "smtp.gmail.com",
                port: 587);

            emailClient.Credentials = new NetworkCredential(
                userName: userName, 
                password: "upslpdpxhsogmfye");

            var message = new MailMessage
            {
                From = new MailAddress(userName),
                Subject = subject,
                Body = body
            };
            emailClient.EnableSsl = true;
            message.To.Add(new MailAddress(to));
            await emailClient.SendMailAsync(message);
        }
    }
}
