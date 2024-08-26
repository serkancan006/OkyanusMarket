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

        public async Task GetProducts()
        {
            // E-posta gönderme işlemi
            var value = await _olimposSoapService.GetProductAllListSoap();
            foreach (var product in value.Data)
            {
                await _productService.TAddAsync(new()
                {
                    ID = Guid.Parse(product.ID),
                    ProductName = product.Name,
                    Price = decimal.Parse(product.Price),
                    AnaBarcode = product.Barcodes[0],
                    ProductTypeID = product.ProductUnit == "Adet" ? 1 : 2, // veri tabanında Adet ilişkili tabloda 1 seninkisi bu yüzden
                    MarkaID = 2,  // Markalar ypaılacak
                    Stock = 10,  // Stoklar yapılacak
                    ANAGRUP = "2",  // kategorileri yapılacak
                    ALTGRUP1 = "0",
                    ALTGRUP2 = "0",
                    ALTGRUP3 = "0",
                });
            }

            Console.WriteLine($"soap servisi çekme çalıştı");
        }

        //public void GetProducts()
        //{
        //    // E-posta gönderme işlemi
        //    var value = _olimposSoapService.GetProductAllListSoap().GetAwaiter().GetResult();
        //    foreach (var product in value.Data)
        //    {
        //        _productService.TAddAsync(new()
        //        {
        //            ProductName = product.Name,
        //            Price = decimal.Parse(product.Price),
        //            AnaBarcode = product.Barcodes[0],
        //            ProductTypeID = product.ProductUnit == "Adet" ? 1 : 2,
        //            MarkaID = 2,
        //            Stock = 10,
        //            ANAGRUP = "2",
        //            ALTGRUP1 = "0",
        //            ALTGRUP2 = "0",
        //            ALTGRUP3 = "0",
        //        }).GetAwaiter().GetResult();
        //    }

        //    Console.WriteLine($"soap servisi çekme");
        //    //return Task.CompletedTask;
        //}
    }
}
