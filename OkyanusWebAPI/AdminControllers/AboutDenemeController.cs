using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;

namespace OkyanusWebAPI.AdminControllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AboutDenemeController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutDenemeController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutService.TWhere(x => x.Status == true).ToList();
            return Ok(values);
        }
    }
}
