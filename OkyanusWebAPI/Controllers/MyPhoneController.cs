using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.MyPhoneVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyPhoneController : ControllerBase
    {
        private readonly IMyPhoneService _MyPhoneService;
        private readonly IMapper _mapper;

        public MyPhoneController(IMyPhoneService MyPhoneService, IMapper mapper)
        {
            _MyPhoneService = MyPhoneService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MyPhoneList()
        {
            var values = _MyPhoneService.TGetListAll();
            var result = _mapper.Map<List<ResultMyPhoneVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMyPhone(CreateMyPhoneVM MyPhoneVM)
        {
            var value = _mapper.Map<MyPhone>(MyPhoneVM);
            _MyPhoneService.TAdd(value);
            return Ok("MyPhone Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMyPhone(int id)
        {
            var values = _MyPhoneService.TGetByID(id);
            _MyPhoneService.TDelete(values);
            return Ok("MyPhone Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMyPhone(UpdateMyPhoneVM MyPhoneVM)
        {
            var value = _mapper.Map<MyPhone>(MyPhoneVM);
            _MyPhoneService.TUpdate(value);
            return Ok("MyPhone Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMyPhone(int id)
        {
            var values = _MyPhoneService.TGetByID(id);
            var result = _mapper.Map<ResultMyPhoneVM>(values);
            return Ok(result);
        }
    }
}
