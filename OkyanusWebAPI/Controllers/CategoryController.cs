using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.CategoryVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _CategoryService.TGetListAll();
            var result = _mapper.Map<List<ResultCategoryVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddCategory(CreateCategoryVM CategoryVM)
        {
            var value = _mapper.Map<Category>(CategoryVM);
            _CategoryService.TAdd(value);
            return Ok("Category Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var values = _CategoryService.TGetByID(id);
            _CategoryService.TDelete(values);
            return Ok("Category Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryVM CategoryVM)
        {
            var value = _mapper.Map<Category>(CategoryVM);
            _CategoryService.TUpdate(value);
            return Ok("Category Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var values = _CategoryService.TGetByID(id);
            var result = _mapper.Map<ResultCategoryVM>(values);
            return Ok(result);
        }
    }
}
