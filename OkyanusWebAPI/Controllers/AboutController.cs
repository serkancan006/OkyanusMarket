using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.AboutVM;
using OkyanusWebAPI.Models.BasketVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService AboutService, IMapper mapper)
        {
            _AboutService = AboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _AboutService.TGetListAll();
            var result = _mapper.Map<List<ResultBasketVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAbout(CreateAboutVM AboutVM)
        {
            var value = _mapper.Map<About>(AboutVM);
            _AboutService.TAdd(value);
            return Ok("About Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _AboutService.TGetByID(id);
            _AboutService.TDelete(values);
            return Ok("About Silindi");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutVM AboutVM)
        {
            var value = _mapper.Map<About>(AboutVM);
            _AboutService.TUpdate(value);
            return Ok("About Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _AboutService.TGetByID(id);
            var result = _mapper.Map<ResultBasketVM>(values);
            return Ok(result);
        }

    }
}
