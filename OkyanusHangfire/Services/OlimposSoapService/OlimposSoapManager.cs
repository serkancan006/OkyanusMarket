using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;

namespace OkyanusHangfire.Services.OlimposSoapService
{
    public class OlimposSoapManager : IOlimposSoapService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OlimposSoapManager> _logger;
        public OlimposSoapManager(HttpClient httpClient, IConfiguration configuration, ILogger<OlimposSoapManager> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ProductAllListSoapResponse> GetProductAllListSoap(string dbUserName = "WEBCRMUSER", string dbPassword = "WEBCRMUSER", string birimNo = "101")
        {
            try
            {
                string xmlData =
                   $@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                <soap:Body>
                    <UrunListesi xmlns=""http://tempuri.org/"">
                        <dbusername>{dbUserName}</dbusername>
                        <dbpassword>{dbPassword}</dbpassword>
                        <birimno>{birimNo}</birimno>
                    </UrunListesi>
                </soap:Body>
            </soap:Envelope>";

                var content = new StringContent(xmlData, Encoding.UTF8, "text/xml");
                content.Headers.Add("SOAPAction", "http://tempuri.org/UrunListesi");
                HttpResponseMessage response = await _httpClient.PostAsync(_configuration["OlimposSoap"], content);
                string result = await response.Content.ReadAsStringAsync();
                // XML'i parse et
                XDocument doc = XDocument.Parse(result);
                // <string> elementinin içeriğini al
                string jsonString = doc.Descendants(XName.Get("UrunListesiResult", "http://tempuri.org/")).FirstOrDefault()?.Value;
                // JSON stringini deserialize etme
                var jsonData = JsonConvert.DeserializeObject<ProductAllListSoapResponse>(jsonString);
                return jsonData ?? new ProductAllListSoapResponse();
            }
            catch (Exception ex)
            {
                _logger.LogError("OlimposSoapManager da istek atarken hata oluştu");
                _logger.LogError("Hata: " + ex.Message);
                throw;
            }
        }

    }
    public class ProductAllListSoapResponse
    {
        public string Count { get; set; }  // count alanı boş string olduğundan string olarak tanımladık
        public string Page { get; set; }   // page alanı da boş string olduğu için string olarak tanımladık
        public List<ProductSoap> Data { get; set; }  // data alanı bir ürün listesi
    }
    public class ProductSoap
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Reyon { get; set; } // null olabileceği için string olarak bırakıyoruz
        public string Price { get; set; }
        public string GenSatFiy { get; set; } // Genel satış fiyatı, burada string olarak bırakıldı
        public string StockQuantity { get; set; }
        public string ProductUnit { get; set; }
        public List<string> Barcodes { get; set; }  // Barcodes bir string listesi olarak tanımlandı
        public string BarcodeStatus { get; set; }
        public string UrunInsertDe { get; set; }  // "Urun Insert Değer"
        public string KdvOran { get; set; }  // KDV oranı
    }
}
