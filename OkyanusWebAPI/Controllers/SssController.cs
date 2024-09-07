using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.SssVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SssController : ControllerBase
    {
        private readonly ISssService _SssService;
        private readonly IMapper _mapper;

        public SssController(ISssService SssService, IMapper mapper)
        {
            _SssService = SssService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SssList()
        {
            var values = await _SssService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultSssVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddSss(CreateSssVM SssVM)
        {
            var value = _mapper.Map<Sss>(SssVM);
            await _SssService.TAddAsync(value);
            return Ok("Sss Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSss(int id)
        {
            var values = await _SssService.TGetByIDAsync(id);
            await _SssService.TDeleteAsync(values);
            return Ok("Sss Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateSss(UpdateSssVM SssVM)
        {
            var value = _mapper.Map<Sss>(SssVM);
            await _SssService.TUpdateAsync(value);
            return Ok("Sss Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSss(int id)
        {
            var values = await _SssService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultSssVM>(values);
            return Ok(result);
        }
    }
}
