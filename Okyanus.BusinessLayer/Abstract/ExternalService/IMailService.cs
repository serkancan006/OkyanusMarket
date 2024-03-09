using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface IMailService
    {
        void SendMailConfirm(string userName, string userMail, string subject, string callbackUrl);
        void SendMailForgotPassword(string userName, string userMail, string subject, string callbackUrl);
        void SendMail(string userName, string userMail, string subject, string message);
    }
}
