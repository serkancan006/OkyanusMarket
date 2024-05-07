using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.CategorizeProductVM;
using OkyanusWebAPI.Models.ProductVM;
using System.Collections.Generic;
using System.Linq.Expressions;

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
        public async Task<IActionResult> GetProduct(int id)
        {
            var values = await _ProductService.TAsQueryable().Include(x => x.Marka).Include(x => x.ProductType).Where(x => x.ID == id).SingleOrDefaultAsync();
            var result = _mapper.Map<ResultProductVM>(values);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ProductList([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TAsQueryable()
                .Include(x => x.Marka)
                .Include(x => x.ProductType)
                .Where(x => x.Status && x.Stock > 0);

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName != null && x.ProductName.ToLower().Contains(filteredParamaters.searchName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
            {
                var group = await _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefaultAsync();
                if (group != null)
                {
                    if (group.ALTGRUP1 == "0")
                    {
                        values = values.Where(x => x.ANAGRUP == group.ANAGRUP);
                    }
                    else if (group.ALTGRUP2 == "0")
                    {
                        values = values.Where(x => x.ANAGRUP == group.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1);
                    }
                    else if (group.ALTGRUP3 == "0")
                    {
                        values = values.Where(x => x.ANAGRUP == group.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2);
                    }
                    else
                    {
                        values = values.Where(x => x.ANAGRUP == group.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3);
                    }
                }
            }

            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                values = values.Where(x => x.Marka != null && x.Marka.MarkaAdı != null && x.Marka.MarkaAdı.ToLower().Contains(filteredParamaters.markaAdi.ToLower()));
            }

            if (!string.IsNullOrEmpty(filteredParamaters.sortField))
            {
                switch (filteredParamaters.sortField.ToLower())
                {
                    case "productname":
                        values = Sort(values, x => x.ProductName, filteredParamaters.sortOrder?.ToLower() == "asc");
                        break;
                    case "price":
                        values = Sort(values, x => (x.DiscountedPrice ?? x.Price), filteredParamaters.sortOrder?.ToLower() == "asc");
                        break;
                    default:
                        break;
                }
            }

            var totalCount = await values.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

            values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize);

            var product = await _mapper.ProjectTo<ResultProductVM>(values).ToListAsync();
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Product = product });
        }
        //[HttpGet]
        //public async Task<IActionResult> ProductList([FromQuery] FilteredProductParamaters filteredParamaters)
        //{
        //    var values = _ProductService.TAsQueryable().Include(x => x.Marka).Include(x => x.ProductType).Where(x => x.Status == true && x.Stock > 0);

        //    if (!string.IsNullOrEmpty(filteredParamaters.searchName))
        //    {
        //        values = values.Where(x => x.ProductName.ToLower().Contains(filteredParamaters.searchName.ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
        //    {
        //        var group = await _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefaultAsync();
        //        if (group?.ALTGRUP1 == "0")
        //        {
        //            values = values.Where(x => x.ANAGRUP == group?.ANAGRUP);
        //        }
        //        else if (group?.ALTGRUP2 == "0")
        //        {
        //            values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1);
        //        }
        //        else if (group?.ALTGRUP3 == "0")
        //        {
        //            values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2);
        //        }
        //        else
        //        {
        //            values = values.Where(x => x.ANAGRUP == group?.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3);
        //        }
        //    }

        //    if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
        //    {
        //        values = values.Where(x => (x.Marka?.MarkaAdı?.ToLower().Contains(filteredParamaters.markaAdi.ToLower()) ?? false));
        //    }

        //    if (!string.IsNullOrEmpty(filteredParamaters.sortField) )
        //    {
        //        switch (filteredParamaters.sortField.ToLower())
        //        {
        //            case "productname":
        //                values = Sort(values, x => x.ProductName, filteredParamaters?.sortOrder?.ToLower() == "asc");
        //                break;
        //            case "price":
        //                values = Sort(values, x => (x.DiscountedPrice ?? x.Price), filteredParamaters?.sortOrder?.ToLower() == "asc");
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    var totalCount = values.Count();
        //    var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

        //    values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize); //sıkıntı olursa tolistasync() ekle

        //    var product = _mapper.Map<List<ResultProductVM>>(values);
        //    return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Product = product });
        //}

        [HttpGet("[action]")]
        public async Task<IActionResult> DiscountedProductList()
        {
            var values = await _ProductService.TWhere(x => x.Status == true && x.Stock > 0 && x.DiscountedPrice != null).ToListAsync();
            var result = _mapper.Map<List<ResultProductVM>>(values);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> HomeCategorizeProductList()
        {
            var list = new List<CategorizeProductVM>();
            var anaGrupList = await _categoryService.TWhere(x => x.ANAGRUP != "0" && x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0").ToListAsync();

            foreach (var anagrup in anaGrupList)
            {
                var altKategoriler = await _categoryService.TWhere(x => x.ANAGRUP == anagrup.ANAGRUP && x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0").Take(4).ToListAsync();

                var a = new List<CategorizeProductVM.Altkategoriler>();
                foreach (var altkategori in altKategoriler)
                {
                    var urunler = await _categoryService.TAsQueryable().Include(x => x.Products).Where(x => x.ANAGRUP == anagrup.ANAGRUP && x.ALTGRUP1 == altkategori.ALTGRUP1 && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0").Select(x => x.Products).FirstOrDefaultAsync();
                    var n = new List<ResultProductVM>();
                    a.Add(new()
                    {
                        AltKategoriAdı = altkategori.GRUPADI,
                        Ürünler = n,
                    });
                    if (urunler != null)
                    {
                        foreach (var urun in urunler)
                        {
                            var value = _mapper.Map<ResultProductVM>(urun);
                            n.Add(value);
                        }
                    }
                   
                }
                list.Add(new CategorizeProductVM()
                {
                    KategoriAdı = anagrup.GRUPADI,
                    AltKategoriler = a
                });
            }
            return Ok(list);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IActionResult> ProductListAll([FromQuery] FilteredProductParamaters filteredParamaters)
        {
            var values = _ProductService.TAsQueryable();

            if (!string.IsNullOrEmpty(filteredParamaters.searchName))
            {
                values = values.Where(x => x.ProductName.ToLower().Contains(filteredParamaters.searchName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filteredParamaters.categoryName))
            {
                var group = _categoryService.TWhere(x => x.GRUPADI == filteredParamaters.categoryName).FirstOrDefault();
                if (group != null)
                    values = values.Where(x => x.ANAGRUP == group.ANAGRUP && x.ALTGRUP1 == group.ALTGRUP1 && x.ALTGRUP2 == group.ALTGRUP2 && x.ALTGRUP3 == group.ALTGRUP3);
            }

            values = values.Include(x => x.Marka).Include(x => x.ProductType).OrderByDescending(x => x.CreatedDate);

            if (!string.IsNullOrEmpty(filteredParamaters.markaAdi))
            {
                values = values.Where(x => x.Marka.MarkaAdı.ToLower().Contains(filteredParamaters.markaAdi.ToLower()));
            }

            var totalCount = await values.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

            values = values.OrderByDescending(x => x.CreatedDate).Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize);

            var product = await _mapper.ProjectTo<ResultProductVM>(values).ToListAsync();
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Product = product });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> AssignCategoryForProductList(int id)
        {
            var product = await _ProductService.TGetByIDAsync(id);

            var productCategoriesList = await _categoryService.TAsQueryable().Select(c => new AssignCategoryForProduct
            {
                CategoryName = c.GRUPADI,
                IsSelected = (c.ANAGRUP == product.ANAGRUP && c.ALTGRUP1 == product.ALTGRUP1 && c.ALTGRUP2 == product.ALTGRUP2 && c.ALTGRUP3 == product.ALTGRUP3)
            }).ToListAsync();

            AssignCategoryForProductListResponse response = new AssignCategoryForProductListResponse()
            {
                ProductName = product?.ProductName,
                ProductCategories = productCategoriesList
            };
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> AssignCategoryForProduct(AssignCategoryRequest request)
        {
            try
            {
                var product = await _ProductService.TGetByIDAsync(request.ProductID);
                if (product == null)
                {
                    return NotFound("Ürün bulunamadı.");
                }

                var group = await _categoryService.TAsQueryable().Where(x => x.GRUPADI == request.GRUPADI).SingleOrDefaultAsync();

                product.ANAGRUP = group.ANAGRUP;
                product.ALTGRUP1 = group.ALTGRUP1;
                product.ALTGRUP2 = group.ALTGRUP2;
                product.ALTGRUP3 = group.ALTGRUP3;
                await _ProductService.TUpdateAsync(product);

                return Ok("Kategorisi başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> ChangeProductImage(ChangeProductImageRequest request)
        {
            var product = await _ProductService.TGetByIDAsync(request.ProductID);
            var oldProductImage = product.ImageUrl;
            product.ImageUrl = request.ImagePath;
            await _ProductService.TUpdateAsync(product);
            if (oldProductImage == null)
            {
                return Ok();
            }
            return Ok(oldProductImage.Substring(1));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductVM ProductVM)
        {
            var category = await _categoryService.TAsQueryable().Where(x => x.GRUPADI == ProductVM.GrupAdı).SingleOrDefaultAsync();
            if (category != null)
            {
                var value = _mapper.Map<Product>(ProductVM);
                value.ANAGRUP = category.ANAGRUP;
                value.ALTGRUP1 = category.ALTGRUP1;
                value.ALTGRUP2 = category.ALTGRUP2;
                value.ALTGRUP3 = category.ALTGRUP3;
                await _ProductService.TAddAsync(value);
                return Ok("Product Eklendi");
            }
            return NotFound("Grup Bulunamadığı için Product Eklenemedi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var values = await _ProductService.TGetByIDAsync(id);
            await _ProductService.TDeleteAsync(values);
            return Ok("Product Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductVM ProductVM)
        {
            var value = _mapper.Map<Product>(ProductVM);
            await _ProductService.TUpdateAsync(value);
            return Ok("Product Güncellendi");
        }

   
        private IQueryable<Product> Sort<T>(IQueryable<Product> source, Expression<Func<Product, T>> keySelector, bool ascending)
        {
            return ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }


    }
}
