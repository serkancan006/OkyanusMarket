using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> ProductTypeList()
        {
            var values = await _ProductTypeService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultProductTypeVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductType(CreateProductTypeVM ProductTypeVM)
        {
            var value = _mapper.Map<ProductType>(ProductTypeVM);
            await _ProductTypeService.TAddAsync(value);
            return Ok("ProductType Eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            var values = await _ProductTypeService.TGetByIDAsync(id);
            await _ProductTypeService.TDeleteAsync(values);
            return Ok("ProductType Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeVM ProductTypeVM)
        {
            var value = _mapper.Map<ProductType>(ProductTypeVM);
            await _ProductTypeService.TUpdateAsync(value);
            return Ok("ProductType Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductType(int id)
        {
            var values = await _ProductTypeService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultProductTypeVM>(values);
            return Ok(result);
        }
    }
}
