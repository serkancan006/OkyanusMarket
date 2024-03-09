using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Concrete.ExternalService
{
    public class MailManager : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMailConfirm(string userName, string userMail, string subject, string callbackUrl)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(_configuration["MailOptions:MailName"], _configuration["MailOptions:MailAdress"]);
            MailboxAddress mailboxAddressTo = new MailboxAddress(userName, userMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = htmlMessage;
            bodyBuilder.HtmlBody = $@"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Mail Onaylama</title>
</head>
<body>
    <div style='width: 80%; padding: 20px; font-family: Arial, sans-serif;'>
        <div style='background-color: #f8f9fa; padding: 20px;'>
            <h1 style='font-size: 28px;'>Hesabınızı Onaylayın</h1>
            <p style='font-size: 16px;'>Lütfen aşağıdaki butona tıklayarak hesabınızı onaylayın.</p>
            <hr style='border: none; border-top: 1px solid #ccc;'>
            <p style='font-size: 16px;'>
                <a href='{callbackUrl}' role='button' style='background-color: #007bff; color: white; padding: 10px 24px; text-align: center; text-decoration: none; display: inline-block; font-size: 20px;'>Onayla</a>
            </p>
        </div>
    </div>
</body>
</html>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = subject;

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(_configuration["MailOptions:MailService"], int.Parse(_configuration["MailOptions:MailPort"]), bool.Parse(_configuration["MailOptions:MailSecurity"]));
                client.Authenticate(_configuration["MailOptions:MailAdress"], _configuration["MailOptions:MailAppKey"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

        }

        public void SendMail(string userName, string userMail, string subject, string message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(_configuration["MailOptions:MailName"], _configuration["MailOptions:MailAdress"]);
            MailboxAddress mailboxAddressTo = new MailboxAddress(userName, userMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = message;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = subject;

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(_configuration["MailOptions:MailService"], int.Parse(_configuration["MailOptions:MailPort"]), bool.Parse(_configuration["MailOptions:MailSecurity"]));
                client.Authenticate(_configuration["MailOptions:MailAdress"], _configuration["MailOptions:MailAppKey"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

        }

        public void SendMailForgotPassword(string userName, string userMail, string subject, string callbackUrl)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(_configuration["MailOptions:MailName"], _configuration["MailOptions:MailAdress"]);
            MailboxAddress mailboxAddressTo = new MailboxAddress(userName, userMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            //bodyBuilder.TextBody = htmlMessage;
            bodyBuilder.HtmlBody = $@"<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>Şifremi Unuttum</title>
</head>
<body>
    <div style='width: 80%; padding: 20px; font-family: Arial, sans-serif;'>
        <div style='background-color: #f8f9fa; padding: 20px;'>
            <h1 style='font-size: 28px;'>Şifrenizi Değiştirin</h1>
            <p style='font-size: 16px;'>Lütfen aşağıdaki butona tıklayarak şifrenizi değiştirebilirsiniz.</p>
            <hr style='border: none; border-top: 1px solid #ccc;'>
            <p style='font-size: 16px;'>
                <a href='{callbackUrl}' role='button' style='background-color: #007bff; color: white; padding: 10px 24px; text-align: center; text-decoration: none; display: inline-block; font-size: 20px;'>Onayla</a>
            </p>
        </div>
    </div>
</body>
</html>";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = subject;

            using (SmtpClient client = new SmtpClient())
            {
                client.Connect(_configuration["MailOptions:MailService"], int.Parse(_configuration["MailOptions:MailPort"]), bool.Parse(_configuration["MailOptions:MailSecurity"]));
                client.Authenticate(_configuration["MailOptions:MailAdress"], _configuration["MailOptions:MailAppKey"]);
                client.Send(mimeMessage);
                client.Disconnect(true);
            }

        }

    }
}
