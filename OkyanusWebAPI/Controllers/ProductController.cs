using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
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
        public IActionResult ProductList()
        {
            var values = _ProductService.TGetListAll();
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
