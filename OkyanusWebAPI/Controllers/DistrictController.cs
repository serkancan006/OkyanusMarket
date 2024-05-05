using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult DistrictList(int sehirId)
        {
            var values = _DistrictService.TWhere(x => x.CityID == sehirId).ToList();
            var result = _mapper.Map<List<ResultDistrictVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddDistrict(CreateDistrictVM DistrictVM)
        {
            var value = _mapper.Map<District>(DistrictVM);
            _DistrictService.TAdd(value);
            return Ok("District Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDistrict(int id)
        {
            var values = _DistrictService.TGetByID(id);
            _DistrictService.TDelete(values);
            return Ok("District Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateDistrict(UpdateDistrictVM DistrictVM)
        {
            var value = _mapper.Map<District>(DistrictVM);
            _DistrictService.TUpdate(value);
            return Ok("District Güncellendi");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetDistrict(int id)
        {
            var values = _DistrictService.TGetByID(id);
            var result = _mapper.Map<ResultDistrictVM>(values);
            return Ok(result);
        }
    }
}
