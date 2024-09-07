using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Okyanus.BusinessLayer.Abstract.ExternalService;

namespace Okyanus.BusinessLayer.Concrete.ExternalService
{
    public class MailManager : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //Mail Onaylama
        public async Task SendMailConfirmAsync(string userName, string userMail, string callbackUrl)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(_configuration["MailOptions:MailName"], _configuration["MailOptions:MailAdress"]);
            MailboxAddress mailboxAddressTo = new MailboxAddress(userName, userMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody =
            $@"<!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Mail Onaylama</title>
            </head>
            <body>
                <div style='width: 80%; padding: 20px; font-family: Arial, sans-serif;'>
                    <div style='background-color: #f8f9fa; padding: 20px;'>
                        <h1 style='font-size: 28px; color: #007bff;'>Üyelik Onayı - Adl Okyanus</h1>
                        <p style='font-size: 16px;'>Merhaba {userName},</p>
                        <p style='font-size: 16px;'>Adl Okyanus ailesine hoş geldiniz! Üyelik başvurunuz için teşekkür ederiz.</p>
                        <p style='font-size: 16px;'>Hesabınızı tam olarak etkinleştirmek için lütfen aşağıdaki bağlantıya tıklayarak e-posta adresinizi doğrulayın:</p>
                        <p style='font-size: 16px;'><a target=""_blank"" href='{callbackUrl}'>Doğrulama Bağlantısı</a></p>
                        <p style='font-size: 16px;'>Bağlantıya tıkladığınızda, üyelik işleminiz tamamlanacak ve Okyanus Market hesabınıza erişebileceksiniz.</p>
                        <p style='font-size: 16px;'>Eğer bu işlemi siz yapmadıysanız, bu e-postayı dikkate almayabilirsiniz.</p>
                        <p style='font-size: 16px;'>Herhangi bir sorunuz varsa, lütfen bizimle iletişime geçmekten çekinmeyin.</p>
                        <p style='font-size: 16px;'>Saygılarımla,</p>
                        <p style='font-size: 16px;'>Adl Okyanus Ekibi</p>
                    </div>
                </div>
            </body>
            </html>
            ";
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Mail Onaylama";

            await SmtpClientSenderAsync(mimeMessage);
        }
        // Mail gönderme
        public async Task SendMailAsync(string userName, string userMail, string subject, string message)
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

            await SmtpClientSenderAsync(mimeMessage);
        }
        //Şifremi Unuttum
        public async Task SendMailForgotPasswordAsync(string userName, string userMail, string callbackUrl)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress(_configuration["MailOptions:MailName"], _configuration["MailOptions:MailAdress"]);
            MailboxAddress mailboxAddressTo = new MailboxAddress(userName, userMail);

            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();

            bodyBuilder.HtmlBody =
            $@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='UTF-8'>
                <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Şifre Sıfırlama</title>
            </head>
            <body>
                <div style='width: 80%; padding: 20px; font-family: Arial, sans-serif;'>
                    <div style='background-color: #f8f9fa; padding: 20px;'>
                        <h1 style='font-size: 28px; color: #007bff;'>Şifre Sıfırlama - Adl Okyanus</h1>
                        <p style='font-size: 16px;'>Merhaba {userName},</p>
                        <p style='font-size: 16px;'>Adl Okyanus hesabınız için şifrenizi sıfırlamanız gerektiğini öğrendik.</p>
                        <p style='font-size: 16px;'>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayınız:</p>
                        <p style='font-size: 16px;'><a target=""_blank"" href='{callbackUrl}'>Şifre Sıfırlama Bağlantısı</a></p>
                        <p style='font-size: 16px;'>Bu bağlantıya tıkladığınızda, şifrenizi sıfırlama işlemi başlatılacaktır.</p>
                        <p style='font-size: 16px;'>Eğer bu işlemi siz yapmadıysanız, bu e-postayı dikkate almayabilirsiniz.</p>
                        <p style='font-size: 16px;'>Herhangi bir sorunuz varsa, lütfen bizimle iletişime geçmekten çekinmeyin.</p>
                        <p style='font-size: 16px;'>Saygılarımla,</p>
                        <p style='font-size: 16px;'>Adl Okyanus Ekibi</p>
                    </div>
                </div>
            </body>
            </html>
            ";

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Sıfırlama";

            await SmtpClientSenderAsync(mimeMessage);
        }
        //SecureSocketOptions.SslOnConnect 465
        //SecureSocketOptions.StartTls 587
        private async Task SmtpClientSenderAsync(MimeMessage mimeMessage)
        {
            using (SmtpClient client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration["MailOptions:MailService"], int.Parse(_configuration["MailOptions:MailPort"]), SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(_configuration["MailOptions:MailAdress"], _configuration["MailOptions:MailAppKey"]);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }

    }
}
