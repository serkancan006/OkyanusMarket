using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.SliderVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _SliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _SliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _SliderService.TGetListAll();
            var result = _mapper.Map<List<ResultSliderVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSlider(CreateSliderVM SliderVM)
        {
            var value = _mapper.Map<Slider>(SliderVM);
            _SliderService.TAdd(value);
            return Ok("Slider Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var values = _SliderService.TGetByID(id);
            var oldImageSlider = values.ImageUrl;
            _SliderService.TDelete(values);
            return Ok(oldImageSlider?.Substring(1));
        }

        //[HttpPut]
        //public IActionResult UpdateSlider(UpdateSliderVM SliderVM)
        //{
        //    var value = _mapper.Map<Slider>(SliderVM);
        //    _SliderService.TUpdate(value);
        //    return Ok("Slider Güncellendi");
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetSlider(int id)
        //{
        //    var values = _SliderService.TGetByID(id);
        //    var result = _mapper.Map<ResultSliderVM>(values);
        //    return Ok(result);
        //}
    }
}
