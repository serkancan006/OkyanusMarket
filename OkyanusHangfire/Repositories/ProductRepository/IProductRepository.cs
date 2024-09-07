using OkyanusHangfire.Models.Dtos.ProductDto;

namespace OkyanusHangfire.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task CreateProduct(CreateProductDto createProductDto);
        Task UpdateProduct(UpdateProductDto updateProductDto);
        Task<GetProductByIdDto> GetProductById(string id);
    }
}
