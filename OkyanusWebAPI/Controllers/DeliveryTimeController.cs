using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult LastDeliveryTimeList()
        {
            var values = _DeliveryTimeService.TWhere(x => x.StartedTime <= DateTime.UtcNow).ToList();
            var result = _mapper.Map<List<ResultDeliveryTimeVM>>(values);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult DeliveryTimeList()
        {
            var values = _DeliveryTimeService.TWhere(x => x.StartedTime > DateTime.UtcNow).ToList();
            var result = _mapper.Map<List<ResultDeliveryTimeVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddDeliveryTime(CreateDeliveryTimeVM DeliveryTimeVM)
        {
            var value = _mapper.Map<DeliveryTime>(DeliveryTimeVM);
            _DeliveryTimeService.TAdd(value);
            return Ok("DeliveryTime Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDeliveryTime(int id)
        {
            var values = _DeliveryTimeService.TGetByID(id);
            _DeliveryTimeService.TDelete(values);
            return Ok("DeliveryTime Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateDeliveryTime(UpdateDeliveryTimeVM DeliveryTimeVM)
        {
            var value = _mapper.Map<DeliveryTime>(DeliveryTimeVM);
            _DeliveryTimeService.TUpdate(value);
            return Ok("DeliveryTime Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDeliveryTime(int id)
        {
            var values = _DeliveryTimeService.TGetByID(id);
            var result = _mapper.Map<ResultDeliveryTimeVM>(values);
            return Ok(result);
        }
    }
}
