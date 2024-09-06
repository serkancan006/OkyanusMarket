using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.DataAccessLayer.Concrete;
using System.Diagnostics;

namespace OkyanusWebAPI.Hangfire.Jobs
{
    public class MyJobs
    {
        private readonly IOlimposSoapService _olimposSoapService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly Context _context;
        public MyJobs(IOlimposSoapService olimposSoapService, IProductService productService, IProductTypeService productTypeService, Context context)
        {
            _olimposSoapService = olimposSoapService;
            _productService = productService;
            _productTypeService = productTypeService;
            _context = context;
        }
        // Ekleme ve Güncellme işlemi yaparken status versende interceptora takıldığı için doğru gitmiyor bunu bir ara hallet
        public async Task GetProducts()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // SOAP servisinden veri çekme
                    var value = await _olimposSoapService.GetProductAllListSoap();
                    // Servisden gelen ürünlerin fiyatlarının sadece 0 dan büyük olanlarını al bide status kontrolü yapman gerek;
                    value.Data = value.Data.Where(x => decimal.Parse(x.Price) > 0).ToList();

                    foreach (var product in value.Data)
                    {
                        // Ürünün veritabanında mevcut olup olmadığını kontrol et
                        var existingProduct = await _productService.TGetByIDAsync(product.ID);

                        if (existingProduct != null)
                        {
                            // Ürün mevcutsa güncelle
                            existingProduct.ProductName = product.Name;
                            existingProduct.Price = decimal.Parse(product.Price);
                            existingProduct.AnaBarcode = product.Barcodes[0];
                            existingProduct.ProductTypeID = product.ProductUnit == "Adet" ? 1 : 2; // "Adet" için veritabanında 1'e eşleme
                            existingProduct.MarkaID = 2;  // Markalar için 
                            existingProduct.Stock = 10;  // Stoklar için 
                            existingProduct.ANAGRUP = "2";  // Kategoriler için 
                            existingProduct.ALTGRUP1 = "0";
                            existingProduct.ALTGRUP2 = "0";
                            existingProduct.ALTGRUP3 = "0";

                            await _productService.TUpdateAsync(existingProduct);
                        }
                        else
                        {
                            // Ürün mevcut değilse yeni kayıt ekle
                            await _productService.TAddAsync(new()
                            {
                                ID = product.ID,
                                ProductName = product.Name,
                                Price = decimal.Parse(product.Price),
                                AnaBarcode = product.Barcodes[0],
                                ProductTypeID = product.ProductUnit == "Adet" ? 1 : 2, // "Adet" için veritabanında 1'e eşleme
                                MarkaID = 2,  // Markalar için 
                                Stock = 10,  // Stoklar için 
                                ANAGRUP = "2",  // Kategoriler için 
                                ALTGRUP1 = "0",
                                ALTGRUP2 = "0",
                                ALTGRUP3 = "0",
                            });
                        }
                    }

                    transaction.Commit();
                    Console.WriteLine("SOAP servisi çağrısı ve veritabanı güncellemesi başarılı oldu.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("soap servisi verisi işlenirken bir hata oluştu. işlem geri alındı.");
                    Console.WriteLine($"hata: {ex.Message}");
                }
            }

            // 2.30 saat sürüyor
            Console.WriteLine($"SOAP servisi işlemi tamamlandı.");
        }

    }
}
