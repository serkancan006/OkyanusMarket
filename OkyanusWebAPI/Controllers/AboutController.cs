using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.AboutVM;

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
        public async Task<IActionResult> AboutList()
        {
            var values = await _AboutService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultAboutVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutVM AboutVM)
        {
            var value = _mapper.Map<About>(AboutVM);
            await _AboutService.TUpdateAsync(value);
            return Ok("About Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _AboutService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultAboutVM>(values);
            return Ok(result);
        }
    }
}
