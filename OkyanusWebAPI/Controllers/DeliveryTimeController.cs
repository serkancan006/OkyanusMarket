using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.DeliveryTimeVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTimeController : ControllerBase
    {
        private readonly IDeliveryTimeService _DeliveryTimeService;
        private readonly IMapper _mapper;

        public DeliveryTimeController(IDeliveryTimeService DeliveryTimeService, IMapper mapper)
        {
            _DeliveryTimeService = DeliveryTimeService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> LastDeliveryTimeList()
        {
            var values = await _DeliveryTimeService.TWhere(x => x.StartedTime <= DateTime.UtcNow.TimeOfDay).ToListAsync();
            var result = _mapper.Map<List<ResultDeliveryTimeVM>>(values);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryTimeList()
        {
            var values = await _DeliveryTimeService.TWhere(x => x.StartedTime > DateTime.UtcNow.TimeOfDay).ToListAsync();
            var result = _mapper.Map<List<ResultDeliveryTimeVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDeliveryTime(CreateDeliveryTimeVM DeliveryTimeVM)
        {
            var value = _mapper.Map<DeliveryTime>(DeliveryTimeVM);
            await _DeliveryTimeService.TAddAsync(value);
            return Ok("DeliveryTime Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryTime(int id)
        {
            var values = await _DeliveryTimeService.TGetByIDAsync(id);
            await _DeliveryTimeService.TDeleteAsync(values);
            return Ok("DeliveryTime Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryTime(UpdateDeliveryTimeVM DeliveryTimeVM)
        {
            var value = _mapper.Map<DeliveryTime>(DeliveryTimeVM);
            await _DeliveryTimeService.TUpdateAsync(value);
            return Ok("DeliveryTime Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryTime(int id)
        {
            var values = await _DeliveryTimeService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultDeliveryTimeVM>(values);
            return Ok(result);
        }
    }
}
