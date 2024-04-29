using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public ProductController(IProductService ProductService, IMapper mapper, IGroupService categoryService)
        {
            _ProductService = ProductService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        private IEnumerable<Product> Sort<T>(IEnumerable<Product> source, Func<Product, T> keySelector, bool ascending)
        {
            //null değerleri sıralamadığı için discounted price değeri geldiğinde indirimlileri başa getirmesi gerek
            //ayrıca price a göre sıraladığında indirmli fiyat varsa bunlarıda göz önüne alınmalı.
            return ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }

        [HttpGet]
        public IActionResult ProductList([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TGetListAll().Where(x => x.Status == true && x.Stock > 0);

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.Contains(filteredParamaters.searchName)).ToList();
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
            //if (filteredParamaters.categoryName != null && filteredParamaters.categoryName.Any() && filteredParamaters.categoryName.Count > 0)
            //{

            //    values = values.Where(p => p.Categories != null && p.Categories.Any(x => filteredParamaters.categoryName.Any(y => y == x.CategoryName))).ToList();
            //}
            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                //values = values.Where(x => x.Marka == filteredParamaters.markaAdi).ToList();
                values = values.Where(x => x.Marka.Contains(filteredParamaters.markaAdi)).ToList();
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
                    //case "indirim":
                    //    values = Sort(values, x => x.DiscountedPrice, filteredParamaters?.sortOrder?.ToLower() == "asc");
                    //    break;
                    // Diğer sıralama alanlarını ekleyin
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
        public IActionResult ProductListAll([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TGetListAll();

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.Contains(filteredParamaters.searchName)).ToList();
            }

            if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
            {
                var group = _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefault();
                values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3).ToList();
            }
            //if (filteredParamaters.categoryName != null && filteredParamaters.categoryName.Any() && filteredParamaters.categoryName.Count > 0)
            //{

            //    values = values.Where(p => p.Categories != null && p.Categories.Any(x => filteredParamaters.categoryName.Any(y => y == x.CategoryName))).ToList();
            //}
            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                values = values.Where(x => x.Marka == filteredParamaters.markaAdi).ToList();
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
            var category = _categoryService.TGetByID(ProductVM.GroupID);
            var value = _mapper.Map<Product>(ProductVM);
            value.ANAGRUP = category.ANAGRUP;
            value.ALTGRUP1 = category.ALTGRUP1;
            value.ALTGRUP2 = category.ALTGRUP2;
            value.ALTGRUP3 = category.ALTGRUP3;
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
