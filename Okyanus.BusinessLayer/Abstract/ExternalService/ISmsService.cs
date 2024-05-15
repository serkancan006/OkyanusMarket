using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface ISmsService
    {
        Task SendOrderNotifySms();
    }
}
