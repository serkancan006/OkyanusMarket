using OkyanusHangfire.Context;
using OkyanusHangfire.Repositories.ProductRepository;
using OkyanusHangfire.Services.OlimposSoapService;

namespace OkyanusHangfire.Hangfire.jobs
{
    public class MyJobs
    {
        private readonly ILogger<MyJobs> _logger;
        private readonly IOlimposSoapService _olimposSoapService;
        private readonly DapperMsSqlContext _context;
        private readonly IProductRepository _productRepository;
        public MyJobs(ILogger<MyJobs> logger, IOlimposSoapService olimposSoapService, DapperMsSqlContext context, IProductRepository productRepository)
        {
            _logger = logger;
            _olimposSoapService = olimposSoapService;
            _context = context;
            _productRepository = productRepository;
        }

        public async Task UpdateProductsBySoapApi()
        {
            _logger.LogInformation($"Hangfire SOAP servisi başlatıldı! Başlanıç zamanı: {DateTime.Now}");
            using (var connection = _context.CreateConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var value = await _olimposSoapService.GetProductAllListSoap();
                        // value.Data = value.Data.Where(x => decimal.Parse(x.Price) > 0).ToList();
                        foreach (var product in value.Data)
                        {
                            var existingProduct = await _productRepository.GetProductById(product.ID);
                            if (existingProduct != null)
                            {
                                await _productRepository.UpdateProduct(new Models.Dtos.ProductDto.UpdateProductDto()
                                {
                                    ID = existingProduct.ID,
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

                                    Status = decimal.Parse(product.Price) > 0 ? true : false,
                                    Description = existingProduct.Description,
                                    DiscountedPrice = existingProduct.DiscountedPrice,
                                    ImageUrl = existingProduct.ImageUrl
                                });
                            }
                            else
                            {
                                await _productRepository.CreateProduct(new()
                                {
                                    ID = product.ID,
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

                                    Status = decimal.Parse(product.Price) > 0 ? true : false,
                                    Description = null,
                                    ImageUrl = null,
                                    DiscountedPrice = null
                                });
                            }
                        }
                        transaction.Commit();
                        _logger.LogInformation("Hangfire SOAP servisi sonucu ürünler başarıyla güncellendi!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        _logger.LogError("Hangfire Soap Servisi sonucu bir hata oluştu!");
                        _logger.LogError("Hata: " + ex.Message);
                    }
                }
            }
            _logger.LogInformation($"Hangfire SOAP servisi sonlandı! Bitiş Zamanı: {DateTime.Now}");
        }

    }
}
