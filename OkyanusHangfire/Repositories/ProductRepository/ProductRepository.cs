using Dapper;
using OkyanusHangfire.Context;
using OkyanusHangfire.Models.Dtos.ProductDto;

namespace OkyanusHangfire.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DapperMsSqlContext _context;
        public ProductRepository(DapperMsSqlContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = @"insert into Products (ID,ProductName,Price,DiscountedPrice,ImageUrl,Description,Stock,AnaBarcode,ANAGRUP,ALTGRUP1,ALTGRUP2,ALTGRUP3,MarkaID,ProductTypeID,CreatedDate,UpdatedDate,Status) 
            values (@ID,@ProductName,@Price,@DiscountedPrice,@ImageUrl,@Description,@Stock,@AnaBarcode,@ANAGRUP,@ALTGRUP1,@ALTGRUP2,@ALTGRUP3,@MarkaID,@ProductTypeID,@CreatedDate,@UpdatedDate,@Status)";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", createProductDto.ID);
            parameters.Add("@ProductName", createProductDto.ProductName);
            parameters.Add("@Price", createProductDto.Price);
            parameters.Add("@DiscountedPrice", createProductDto.DiscountedPrice);
            parameters.Add("@ImageUrl", createProductDto.ImageUrl);
            parameters.Add("@Description", createProductDto.Description);
            parameters.Add("@Stock", createProductDto.Stock);
            parameters.Add("@AnaBarcode", createProductDto.AnaBarcode);
            parameters.Add("@ANAGRUP", createProductDto.ANAGRUP);
            parameters.Add("@ALTGRUP1", createProductDto.ALTGRUP1);
            parameters.Add("@ALTGRUP2", createProductDto.ALTGRUP2);
            parameters.Add("@ALTGRUP3", createProductDto.ALTGRUP3);
            parameters.Add("@MarkaID", createProductDto.MarkaID);
            parameters.Add("@ProductTypeID", createProductDto.ProductTypeID);
            parameters.Add("@CreatedDate", DateTime.Now);
            parameters.Add("@UpdatedDate", DateTime.Now);
            parameters.Add("@Status", createProductDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task UpdateProduct(UpdateProductDto updateProductDto)
        {
            string query = @"
                            UPDATE Products
                            SET ProductName = @ProductName,
                                Price = @Price,
                                DiscountedPrice = @DiscountedPrice,
                                ImageUrl = @ImageUrl,
                                Description = @Description,
                                Stock = @Stock,
                                AnaBarcode = @AnaBarcode,
                                ANAGRUP = @ANAGRUP,
                                ALTGRUP1 = @ALTGRUP1,
                                ALTGRUP2 = @ALTGRUP2,
                                ALTGRUP3 = @ALTGRUP3,
                                MarkaID = @MarkaID,
                                ProductTypeID = @ProductTypeID,
                                UpdatedDate = @UpdatedDate,
                                Status = @Status
                            WHERE ID = @ID";
            var parameters = new DynamicParameters();
            parameters.Add("@ID", updateProductDto.ID);
            parameters.Add("@ProductName", updateProductDto.ProductName);
            parameters.Add("@Price", updateProductDto.Price);
            parameters.Add("@DiscountedPrice", updateProductDto.DiscountedPrice);
            parameters.Add("@ImageUrl", updateProductDto.ImageUrl);
            parameters.Add("@Description", updateProductDto.Description);
            parameters.Add("@Stock", updateProductDto.Stock);
            parameters.Add("@AnaBarcode", updateProductDto.AnaBarcode);
            parameters.Add("@ANAGRUP", updateProductDto.ANAGRUP);
            parameters.Add("@ALTGRUP1", updateProductDto.ALTGRUP1);
            parameters.Add("@ALTGRUP2", updateProductDto.ALTGRUP2);
            parameters.Add("@ALTGRUP3", updateProductDto.ALTGRUP3);
            parameters.Add("@MarkaID", updateProductDto.MarkaID);
            parameters.Add("@ProductTypeID", updateProductDto.ProductTypeID);
            parameters.Add("@UpdatedDate", DateTime.Now);
            parameters.Add("@Status", updateProductDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetProductByIdDto> GetProductById(string id)
        {
            string query = "Select * From Products Where ID=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

    }
}
