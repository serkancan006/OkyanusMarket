using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.MarkaVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        private readonly IMarkaService _MarkaService;
        private readonly IMapper _mapper;

        public MarkaController(IMarkaService MarkaService, IMapper mapper)
        {
            _MarkaService = MarkaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MarkaList()
        {
            var values = await _MarkaService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultMarkaVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddMarka(CreateMarkaVM MarkaVM)
        {
            var value = _mapper.Map<Marka>(MarkaVM);
            await _MarkaService.TAddAsync(value);
            return Ok("Marka Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarka(int id)
        {
            var values = await _MarkaService.TGetByIDAsync(id);
            await _MarkaService.TDeleteAsync(values);
            return Ok("Marka Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateMarka(UpdateMarkaVM MarkaVM)
        {
            var value = _mapper.Map<Marka>(MarkaVM);
            await _MarkaService.TUpdateAsync(value);
            return Ok("Marka Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarka(int id)
        {
            var values = await _MarkaService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultMarkaVM>(values);
            return Ok(result);
        }
    }
}
