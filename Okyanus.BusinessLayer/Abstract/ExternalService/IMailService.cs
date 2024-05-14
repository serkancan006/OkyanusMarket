using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface IMailService
    {
        Task SendMailConfirmAsync(string userName, string userMail, string callbackUrl);
        Task SendMailForgotPasswordAsync(string userName, string userMail, string callbackUrl);
        Task SendMailAsync(string userName, string userMail, string subject, string message);
    }
}
