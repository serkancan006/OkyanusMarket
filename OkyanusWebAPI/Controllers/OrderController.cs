using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.OrderVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService OrderService, IMapper mapper)
        {
            _OrderService = OrderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _OrderService.TGetListAll();
            var result = _mapper.Map<List<ResultOrderVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrder(CreateOrderVM OrderVM)
        {
            var value = _mapper.Map<Order>(OrderVM);
            _OrderService.TAdd(value);
            return Ok("Order Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var values = _OrderService.TGetByID(id);
            _OrderService.TDelete(values);
            return Ok("Order Silindi");
        }

        [HttpPut]
        public IActionResult UpdateOrder(UpdateOrderVM OrderVM)
        {
            var value = _mapper.Map<Order>(OrderVM);
            _OrderService.TUpdate(value);
            return Ok("Order Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var values = _OrderService.TGetByID(id);
            var result = _mapper.Map<ResultOrderVM>(values);
            return Ok(result);
        }
    }
}
