using Microsoft.Extensions.Configuration;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Concrete.ExternalService
{
    public class SmsManager : ISmsService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SmsManager(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task SendOrderNotifySms()
        {
            try
            {
                // string endpoint = "https://api.netgsm.com.tr/sms/send/otp";
                string xmlData =
                $@"
                <?xml version=""1.0""?>
                <mainbody>
                   <header>
                       <usercode>kullanıcıadı</usercode>
                       <password>şifre</password>
                       <msgheader>mesajbaşlığı</msgheader>
                       <appkey>xxx</appkey> 
                   </header>
                   <body>
                       <msg>
                           <![CDATA[TestMesajı]]>
                       </msg>
                       <no>5XXXXXXXXX</no>
                   </body>
                </mainbody>
                ";

                StringContent content = new StringContent(xmlData, Encoding.UTF8, "application/xml");
                //HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);
                HttpResponseMessage response = await _httpClient.PostAsync(_configuration["NetGsm"], content);
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: " + responseContent);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
