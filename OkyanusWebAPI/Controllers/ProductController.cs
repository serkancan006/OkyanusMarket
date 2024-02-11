using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.DataAccessLayer.Concrete;
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
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
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
