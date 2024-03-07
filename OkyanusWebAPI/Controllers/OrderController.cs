using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Hubs;
using OkyanusWebAPI.Models.OrderDetailVM;
using OkyanusWebAPI.Models.OrderVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IHubContext<SignalRHub> _hubContext;

        public OrderController(IOrderService OrderService, IMapper mapper, IOrderDetailService orderDetailService, IHubContext<SignalRHub> hubContext)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _OrderService.TGetListAll();
            var result = _mapper.Map<List<ResultOrderVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderRequestVM createOrderRequestVM)
        {
            CreateOrderVM createOrderVM = new CreateOrderVM() 
            {
                Description = createOrderRequestVM.Description,
                OrderAdress = createOrderRequestVM.OrderAdress,
                OrderApartman = createOrderRequestVM.OrderApartmanNo,
                OrderFirstName = createOrderRequestVM.OrderFirstName,
                OrderDaire = createOrderRequestVM.OrderDaireNo,
                OrderMail = createOrderRequestVM.OrderMail,
                OrderSurname = createOrderRequestVM.OrderSurname,
                OrderIlce = createOrderRequestVM.OrderIlce,
                OrderSehir = createOrderRequestVM.OrderSehir,
                OrderPhone = createOrderRequestVM.OrderPhone,
                OrderKat = createOrderRequestVM.OrderKat,
                TotalPrice = createOrderRequestVM.TotalPrice,
            };
            var value = _mapper.Map<Order>(createOrderVM);
            _OrderService.TAdd(value);
            List<CreateOrderDetailVM> createOrderDetailVM = new List<CreateOrderDetailVM>();
            createOrderDetailVM.AddRange(createOrderRequestVM.OrderItems.Select(item => new CreateOrderDetailVM()
            {
                ProductID = item.ProductId,
                Count = item.Quantity,
                UnitPrice = item.Price,
                TotalPrice = item.TotalPrice,
                OrderID = value.ID,
            }));
            var orderItemList = _mapper.Map<List<OrderDetail>>(createOrderDetailVM);
            _orderDetailService.TAddRange(orderItemList);
            var orders = _OrderService.TGetListAll();
            await _hubContext.Clients.All.SendAsync("ReceiveOrder", orders);
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
