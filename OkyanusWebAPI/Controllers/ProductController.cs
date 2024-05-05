using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.ProductVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IGroupService _categoryService;
        private readonly IMapper _mapper;
        private readonly IMarkaService _markaService;

        public ProductController(IProductService ProductService, IMapper mapper, IGroupService categoryService, IMarkaService markaService)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _categoryService = categoryService;
            _markaService = markaService;
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var values = _ProductService.TAsQueryable().Include(x => x.Marka).Include(x => x.ProductType).Where(x => x.ID == id).SingleOrDefault();
            var result = _mapper.Map<ResultProductVM>(values);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult ProductList([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TAsQueryable().Include(x => x.Marka).Include(x => x.ProductType).Where(x => x.Status == true && x.Stock > 0).ToList();

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.ToLower().Contains(filteredParamaters.searchName.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
            {
                var group = _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefault();
                if (group?.ALTGRUP1 == "0")
                {
                    values = values.Where(x => x.ANAGRUP == group?.ANAGRUP).ToList();
                }
                else if (group?.ALTGRUP2 == "0")
                {
                    values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1).ToList();
                }
                else if (group?.ALTGRUP3 == "0")
                {
                    values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2).ToList();
                }
                else
                {
                    values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3).ToList();
                }
            }
       
            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                values = values.Where(x => (x.Marka?.MarkaAdı?.ToLower().Contains(filteredParamaters.markaAdi.ToLower()) ?? false)).ToList();
            }

            if (!string.IsNullOrEmpty(filteredParamaters.sortField) )
            {
                switch (filteredParamaters.sortField.ToLower())
                {
                    case "productname":
                        values = Sort(values, x => x.ProductName, filteredParamaters?.sortOrder?.ToLower() == "asc");
                        break;
                    case "price":
                        values = Sort(values, x => (x.DiscountedPrice ?? x.Price), filteredParamaters?.sortOrder?.ToLower() == "asc");
                        break;
                    default:
                        break;
                }
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
            var values = _ProductService.TWhere(x => x.Status == true && x.Stock > 0 && x.DiscountedPrice != null).ToList();
            var result = _mapper.Map<List<ResultProductVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public IActionResult ProductListAll([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TAsQueryable().Include(x => x.Marka).Include(x => x.ProductType).OrderByDescending(x => x.CreatedDate).ToList();

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.ToLower().Contains(filteredParamaters.searchName.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
            {
                var group = _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefault();
                values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3).ToList();
            }
        
            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                values = values.Where(x => (x.Marka?.MarkaAdı?.ToLower().Contains(filteredParamaters.markaAdi.ToLower()) ?? false)).ToList();
            }

            var totalCount = values.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

            values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize).ToList();

            var product = _mapper.Map<List<ResultProductVM>>(values).ToList();
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Product = product });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult AssignCategoryForProductList(int id)
        {
            var product = _ProductService.TGetByID(id);

            var productCategoriesList = _categoryService.TGetListAll().Select(c => new AssignCategoryForProduct
            {
                CategoryID = c.ID,
                CategoryName = c.GRUPADI,
                IsSelected = (c.ANAGRUP == product.ANAGRUP && c.ALTGRUP1 == product.ALTGRUP1 && c.ALTGRUP2 == product.ALTGRUP2 && c.ALTGRUP3 == product.ALTGRUP3)
            }).ToList();

            AssignCategoryForProductListResponse response = new AssignCategoryForProductListResponse()
            {
                ProductName = product?.ProductName,
                ProductCategories = productCategoriesList
            };
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public IActionResult AssignCategoryForProduct(AssignCategoryRequest request)
        {
            try
            {
                var product = _ProductService.TGetByID(request.ProductID);
                if (product == null)
                {
                    return NotFound("Ürün bulunamadı.");
                }

                var group = _categoryService.TGetByID(request.CategoryID);

                product.ANAGRUP = group.ANAGRUP;
                product.ALTGRUP1 = group.ALTGRUP1;
                product.ALTGRUP2 = group.ALTGRUP2;
                product.ALTGRUP3 = group.ALTGRUP3;
                _ProductService.TUpdate(product);

                return Ok("Kategorisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddProduct(CreateProductVM ProductVM)
        {
            var category = _categoryService.TGetByID(ProductVM.GroupID);
            var value = _mapper.Map<Product>(ProductVM);
            value.ANAGRUP = category.ANAGRUP;
            value.ALTGRUP1 = category.ALTGRUP1;
            value.ALTGRUP2 = category.ALTGRUP2;
            value.ALTGRUP3 = category.ALTGRUP3;
            _ProductService.TAdd(value);
            return Ok("Product Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var values = _ProductService.TGetByID(id);
            _ProductService.TDelete(values);
            return Ok("Product Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductVM ProductVM)
        {
            var value = _mapper.Map<Product>(ProductVM);
            _ProductService.TUpdate(value);
            return Ok("Product Güncellendi");
        }

   

        private List<Product> Sort<T>(List<Product> source, Func<Product, T> keySelector, bool ascending)
        {
            return ascending ? source.OrderBy(keySelector).ToList() : source.OrderByDescending(keySelector).ToList();
        }

    }
}
