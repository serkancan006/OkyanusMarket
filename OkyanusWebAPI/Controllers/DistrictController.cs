using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.DistrictVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _DistrictService;
        private readonly IMapper _mapper;

        public DistrictController(IDistrictService DistrictService, IMapper mapper)
        {
            _DistrictService = DistrictService;
            _mapper = mapper;
        }

        [HttpGet("{sehirId}")]
        public async Task<IActionResult> DistrictList(int sehirId)
        {
            var values = await _DistrictService.TWhere(x => x.CityID == sehirId).ToListAsync();
            var result = _mapper.Map<List<ResultDistrictVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDistrict(CreateDistrictVM DistrictVM)
        {
            var value = _mapper.Map<District>(DistrictVM);
            await _DistrictService.TAddAsync(value);
            return Ok("District Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var values = await _DistrictService.TGetByIDAsync(id);
            await _DistrictService.TDeleteAsync(values);
            return Ok("District Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateDistrict(UpdateDistrictVM DistrictVM)
        {
            var value = _mapper.Map<District>(DistrictVM);
            await _DistrictService.TUpdateAsync(value);
            return Ok("District Güncellendi");
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDistrict(int id)
        {
            var values = await _DistrictService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultDistrictVM>(values);
            return Ok(result);
        }
    }
}
