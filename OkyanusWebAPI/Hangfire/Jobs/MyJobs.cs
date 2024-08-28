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

        public void SendExample(string email)
        {
            // E-posta gönderme işlemi
            Console.WriteLine($"e-posta gönderme işlemi {email}");
        }

        public async Task GetProducts()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // SOAP servisinden veri çekme
                    var value = await _olimposSoapService.GetProductAllListSoap();

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
                            existingProduct.MarkaID = 2;  // Markalar için placeholder
                            existingProduct.Stock = 10;  // Stoklar için placeholder
                            existingProduct.ANAGRUP = "2";  // Kategoriler için placeholder
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
                                MarkaID = 2,  // Markalar için placeholder
                                Stock = 10,  // Stoklar için placeholder
                                ANAGRUP = "2",  // Kategoriler için placeholder
                                ALTGRUP1 = "0",
                                ALTGRUP2 = "0",
                                ALTGRUP3 = "0",
                            });
                        }
                    }

                    // Tüm işlemler başarılı olursa işlemi onayla
                    transaction.Commit();
                    Console.WriteLine("SOAP servisi çağrısı ve veritabanı güncellemesi başarılı oldu.");
                }
                catch (Exception ex)
                {
                    // Herhangi bir hata durumunda işlemi geri al
                    // 2.30 saat sürüyor
                    transaction.Rollback();
                    Console.WriteLine("SOAP servisi verisi işlenirken bir hata oluştu. İşlem geri alındı.");
                    Console.WriteLine($"Hata: {ex.Message}");
                }
            }

            // Stopwatch nesnesini durdur
            stopwatch.Stop();
            Console.WriteLine($"SOAP servisi işlemi tamamlandı. Geçen süre: {stopwatch.ElapsedMilliseconds} milisaniye.");
        }

    }
}
