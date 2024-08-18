using Okyanus.BusinessLayer.Concrete.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Abstract.ExternalService
{
    public interface IOlimposSoapService
    {
        Task<ProductAllListSoapResponse> GetProductAllListSoap(string dbUserName = "WEBCRMUSER", string dbPassword = "WEBCRMUSER", string birimNo = "101");
    }
}
