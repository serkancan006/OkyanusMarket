using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.SocialMediaVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService SocialMediaService, IMapper mapper)
        {
            _SocialMediaService = SocialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _SocialMediaService.TGetListAll();
            var result = _mapper.Map<List<ResultSocialMediaVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaVM SocialMediaVM)
        {
            var value = _mapper.Map<SocialMedia>(SocialMediaVM);
            _SocialMediaService.TAdd(value);
            return Ok("SocialMedia Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _SocialMediaService.TGetByID(id);
            _SocialMediaService.TDelete(values);
            return Ok("SocialMedia Silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaVM SocialMediaVM)
        {
            var value = _mapper.Map<SocialMedia>(SocialMediaVM);
            _SocialMediaService.TUpdate(value);
            return Ok("SocialMedia Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _SocialMediaService.TGetByID(id);
            var result = _mapper.Map<ResultSocialMediaVM>(values);
            return Ok(result);
        }
    }
}
