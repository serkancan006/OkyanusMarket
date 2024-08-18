using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Abstract.ExternalService;

namespace OkyanusWebAPI.Hangfire.Jobs
{
    public class MyJobs
    {
        private readonly IOlimposSoapService _olimposSoapService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        public MyJobs(IOlimposSoapService olimposSoapService, IProductService productService, IProductTypeService productTypeService)
        {
            _olimposSoapService = olimposSoapService;
            _productService = productService;
            _productTypeService = productTypeService;
        }

        public void SendEmail(string email)
        {
            // E-posta gönderme işlemi
            Console.WriteLine($"e-posta gönderme işlemi {email}");
        }

        public void GetProducts()
        {
            // E-posta gönderme işlemi
            var value = _olimposSoapService.GetProductAllListSoap().GetAwaiter().GetResult();
            foreach (var product in value.Data)
            {
                _productService.TAddAsync(new()
                {
                    ProductName = product.Name,
                    Price = decimal.Parse(product.Price),
                    AnaBarcode = product.Barcodes[0],
                    ProductTypeID = product.ProductUnit == "Adet" ? 1 : 2,
                    MarkaID = 2,
                    Stock = 10,
                    ANAGRUP = "2",
                    ALTGRUP1 = "0",
                    ALTGRUP2 = "0",
                    ALTGRUP3 = "0",
                }).GetAwaiter().GetResult();
            }

            Console.WriteLine($"soap servisi çekme");
            //return Task.CompletedTask;
        }
    }
}
