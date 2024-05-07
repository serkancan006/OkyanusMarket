using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> MyPhoneList()
        {
            var values = await _MyPhoneService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultMyPhoneVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddMyPhone(CreateMyPhoneVM MyPhoneVM)
        {
            var value = _mapper.Map<MyPhone>(MyPhoneVM);
            await _MyPhoneService.TAddAsync(value);
            return Ok("MyPhone Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMyPhone(int id)
        {
            var values = await _MyPhoneService.TGetByIDAsync(id);
            await _MyPhoneService.TDeleteAsync(values);
            return Ok("MyPhone Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateMyPhone(UpdateMyPhoneVM MyPhoneVM)
        {
            var value = _mapper.Map<MyPhone>(MyPhoneVM);
            await _MyPhoneService.TUpdateAsync(value);
            return Ok("MyPhone Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMyPhone(int id)
        {
            var values = await _MyPhoneService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultMyPhoneVM>(values);
            return Ok(result);
        }
    }
}
