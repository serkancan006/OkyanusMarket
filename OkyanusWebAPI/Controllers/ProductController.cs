using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.ProductVM;
using Org.BouncyCastle.Asn1.Ocsp;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper, ICategoryService categoryService)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult ProductList([FromQuery] FilteredParamaters filteredParamaters)
        {
            var values = _ProductService.TInclude(x => x.Categories).ToList();

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.Contains(filteredParamaters.searchName)).ToList();
            }

            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    values = values.Where(p => p.Categories != null && p.Categories.Any(x => x.CategoryName == categoryName)).ToList();
            //}
            if (filteredParamaters.categoryNames != null && filteredParamaters.categoryNames.Any() && filteredParamaters.categoryNames.Count > 0)
            {
               
                values = values.Where(p => p.Categories != null && p.Categories.Any(x => filteredParamaters.categoryNames.Any(y => y == x.CategoryName))).ToList();
            }

            var totalCount = values.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

            values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize).ToList();

            var product = _mapper.Map<List<ResultProductVM>>(values).ToList();
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Product = product });
        }



        [HttpGet("[action]")]
        public IActionResult DiscountedProductList()
        {
            var values = _ProductService.TGetListAll();
            values = values.Where(x => x.DiscountedPrice != null).ToList();
            var result = _mapper.Map<List<ResultProductVM>>(values);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult AssignCategoryForProductList(int id)
        {
            var product = _ProductService.TInclude(x => x.Categories).FirstOrDefault(y => y.ID == id);
           
            var productCategoriesList = _categoryService.TGetListAll().Select(c => new AssignCategoryForProduct
            {
                CategoryID = c.ID,
                CategoryName = c.CategoryName,
                IsSelected = product?.Categories.Any(pc => pc.ID == c.ID) ?? false
            }).ToList();

            AssignCategoryForProductListResponse response = new AssignCategoryForProductListResponse()
            {
                ProductName = product?.ProductName,
                ProductCategories = productCategoriesList
            };
            return Ok(response);
        }

        [HttpPost("[action]")]
        public IActionResult AssignCategoryForProduct(AssignCategoryRequest request)
        {
            try
            {
                var product = _ProductService.TInclude(x => x.Categories).FirstOrDefault(y => y.ID == request.ProductID);
                if (product == null)
                {
                    return NotFound("Ürün bulunamadı.");
                }
                product.Categories.Clear();

                var categoriesToAdd = _categoryService.TGetListAll().Where(c => request.CategoryIDs.Any(id => id == c.ID) && !product.Categories.Any(pc => pc.ID == c.ID)).ToList();

                product.Categories.AddRange(categoriesToAdd);
                _ProductService.TUpdate(product);

                return Ok("Kategoriler başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPost("[action]")]
        public IActionResult ChangeProductImage(ChangeProductImageRequest request)
        {
            var product = _ProductService.TGetByID(request.ProductID);
            var oldProductImage = product.ImageUrl;
            product.ImageUrl = request.ImagePath;
            _ProductService.TUpdate(product);
            if (oldProductImage == null)
            {
                return Ok();
            }
            return Ok(oldProductImage.Substring(1));
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductVM ProductVM)
        {
            var value = _mapper.Map<Product>(ProductVM);
            _ProductService.TAdd(value);
            return Ok("Product Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values = _ProductService.TGetByID(id);
            _ProductService.TDelete(values);
            return Ok("Product Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductVM ProductVM)
        {
            var value = _mapper.Map<Product>(ProductVM);
            _ProductService.TUpdate(value);
            return Ok("Product Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = _ProductService.TGetByID(id);
            var result = _mapper.Map<ResultProductVM>(values);
            return Ok(result);
        }
    }
}
