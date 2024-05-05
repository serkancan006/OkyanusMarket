using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.CityVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _CityService;
        private readonly IMapper _mapper;

        public CityController(ICityService CityService, IMapper mapper)
        {
            _CityService = CityService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CityList()
        {
            var values = _CityService.TInclude(x => x.Districts).ToList();
            var result = _mapper.Map<List<ResultCityVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCity(CreateCityVM CityVM)
        {
            var value = _mapper.Map<City>(CityVM);
            _CityService.TAdd(value);
            return Ok("City Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var values = _CityService.TGetByID(id);
            _CityService.TDelete(values);
            return Ok("City Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateCity(UpdateCityVM CityVM)
        {
            var value = _mapper.Map<City>(CityVM);
            _CityService.TUpdate(value);
            return Ok("City Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var values = _CityService.TGetByID(id);
            var result = _mapper.Map<ResultCityVM>(values);
            return Ok(result);
        }
    }
}
