using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> CityList()
        {
            var values = await _CityService.TInclude(x => x.Districts).ToListAsync();
            var result = _mapper.Map<List<ResultCityVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCity(CreateCityVM CityVM)
        {
            var value = _mapper.Map<City>(CityVM);
            await _CityService.TAddAsync(value);
            return Ok("City Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var values = await _CityService.TGetByIDAsync(id);
            await _CityService.TDeleteAsync(values);
            return Ok("City Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCity(UpdateCityVM CityVM)
        {
            var value = _mapper.Map<City>(CityVM);
            await _CityService.TUpdateAsync(value);
            return Ok("City Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id)
        {
            var values = await _CityService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultCityVM>(values);
            return Ok(result);
        }
    }
}
