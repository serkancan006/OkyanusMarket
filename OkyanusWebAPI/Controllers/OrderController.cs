using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
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
        private readonly IProductService _productService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserAdresService _userAdresService;

        public OrderController(IOrderService OrderService, IMapper mapper, IOrderDetailService orderDetailService, IHubContext<SignalRHub> hubContext, IProductService productService, UserManager<AppUser> userManager, IUserAdresService userAdresService)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _hubContext = hubContext;
            _productService = productService;
            _userManager = userManager;
            _userAdresService = userAdresService;
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).ToList();
            var result = _mapper.Map<List<ResultOrderVM>>(values);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderRequestVM createOrderRequestVM)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var adres = _userAdresService.TGetByID(createOrderRequestVM.UserAdresID);
            CreateOrderVM createOrderVM = new CreateOrderVM() 
            {
                Description = createOrderRequestVM.Description,

                AlternatifUrun = createOrderRequestVM.AlternatifUrun,
                TeslimatYontemi = createOrderRequestVM.TeslimatYontemi,
                TeslimatSaati = createOrderRequestVM.TeslimatSaati,

                OrderPhone = createOrderRequestVM.TelefonNo,

                OrderAdress = adres.UserAdress,
                OrderApartman = adres.UserApartman,
                OrderDaire = adres.UserDaire,
                OrderKat = adres.UserKat,
                OrderIlce = adres.UserIlce,
                OrderSehir = adres.UserSehir,
                TotalPrice = createOrderRequestVM.OrderItems.Sum(x => (_productService.TGetByID(x.ProductId).DiscountedPrice ?? _productService.TGetByID(x.ProductId).Price) * x.Quantity),
            };
            var value = _mapper.Map<Order>(createOrderVM);
            value.OrderSurname = user.Surname;
            value.OrderFirstName = user.Name;
            //value.OrderPhone = user.PhoneNumber;
            value.OrderUserPhone = user.PhoneNumber;
            value.OrderMail = user.Email;
            value.AppUserID = user.Id;
            _OrderService.TAdd(value);
            List<CreateOrderDetailVM> createOrderDetailVM = new List<CreateOrderDetailVM>();
            createOrderDetailVM.AddRange(createOrderRequestVM.OrderItems.Select(item => new CreateOrderDetailVM()
            {
                ProductID = item.ProductId,
                Count = item.Quantity,
                UnitPrice = _productService.TGetByID(item.ProductId).DiscountedPrice ?? _productService.TGetByID(item.ProductId).Price,
                OrderID = value.ID,
            }));
            var orderItemList = _mapper.Map<List<OrderDetail>>(createOrderDetailVM);
            _orderDetailService.TAddRange(orderItemList);
            return Ok("Order Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var values = _OrderService.TGetByID(id);
            _OrderService.TDelete(values);
            return Ok("Order Silindi");
        }

        //[HttpPut]
        //public IActionResult UpdateOrder(UpdateOrderVM OrderVM)
        //{
        //    var value = _mapper.Map<Order>(OrderVM);
        //    _OrderService.TUpdate(value);
        //    return Ok("Order Güncellendi");
        //}

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Where(x => x.ID == id).SingleOrDefault();
            var result = _mapper.Map<ResultOrderVM>(values);
            return Ok(result);
        }
    }
}
