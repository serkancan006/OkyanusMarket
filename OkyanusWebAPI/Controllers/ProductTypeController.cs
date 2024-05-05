using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.ProductTypeVM;

namespace OkyanusWebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService _ProductTypeService;
        private readonly IMapper _mapper;

        public ProductTypeController(IProductTypeService ProductTypeService, IMapper mapper)
        {
            _ProductTypeService = ProductTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductTypeList()
        {
            var values = _ProductTypeService.TGetListAll();
            var result = _mapper.Map<List<ResultProductTypeVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddProductType(CreateProductTypeVM ProductTypeVM)
        {
            var value = _mapper.Map<ProductType>(ProductTypeVM);
            _ProductTypeService.TAdd(value);
            return Ok("ProductType Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductType(int id)
        {
            var values = _ProductTypeService.TGetByID(id);
            _ProductTypeService.TDelete(values);
            return Ok("ProductType Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProductType(UpdateProductTypeVM ProductTypeVM)
        {
            var value = _mapper.Map<ProductType>(ProductTypeVM);
            _ProductTypeService.TUpdate(value);
            return Ok("ProductType Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetProductType(int id)
        {
            var values = _ProductTypeService.TGetByID(id);
            var result = _mapper.Map<ResultProductTypeVM>(values);
            return Ok(result);
        }
    }
}
