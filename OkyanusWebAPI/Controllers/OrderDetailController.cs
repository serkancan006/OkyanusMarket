using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.OrderDetailVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _OrderDetailService;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailService OrderDetailService, IMapper mapper)
        {
            _OrderDetailService = OrderDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult OrderDetailList()
        {
            var values = _OrderDetailService.TGetListAll();
            var result = _mapper.Map<List<ResultOrderDetailVM>>(values);
            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult OrderDetailList(int id)
        {
            var values = _OrderDetailService.TInclude(y=>y.Product).Where(x => x.OrderID == id).ToList();
            var result = _mapper.Map<List<ResultOrderDetailVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddOrderDetail(CreateOrderDetailVM OrderDetailVM)
        {
            var value = _mapper.Map<OrderDetail>(OrderDetailVM);
            _OrderDetailService.TAdd(value);
            return Ok("OrderDetail Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var values = _OrderDetailService.TGetByID(id);
            _OrderDetailService.TDelete(values);
            return Ok("OrderDetail Silindi");
        }

        [HttpPut]
        public IActionResult UpdateOrderDetail(UpdateOrderDetailVM OrderDetailVM)
        {
            var value = _mapper.Map<OrderDetail>(OrderDetailVM);
            _OrderDetailService.TUpdate(value);
            return Ok("OrderDetail Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            var values = _OrderDetailService.TGetByID(id);
            var result = _mapper.Map<ResultOrderDetailVM>(values);
            return Ok(result);
        }
    }
}
