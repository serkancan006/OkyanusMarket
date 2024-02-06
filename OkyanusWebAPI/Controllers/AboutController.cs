using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.ValidationRules;
using Okyanus.EntityLayer.Entities;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private readonly IValidator<About> _validator;

        public AboutController(IAboutService aboutService, IMapper mapper, IValidator<About> validator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //[HttpPost] için yapılır... Index(About about)
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //var validator = new AboutValidators();
            //var validationResult = validator.Validate(about);
            ////var validationResult = _validator.Validate(about);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            var values = _aboutService.TWhere(x => x.Status == true).ToList();
            return Ok(values);
        }
    }
}
