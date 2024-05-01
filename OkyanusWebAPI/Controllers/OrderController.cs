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
using OkyanusWebAPI.Models;
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
        private readonly IDeliveryTimeService _deliveryTimeService;

        public OrderController(IOrderService OrderService, IMapper mapper, IOrderDetailService orderDetailService, IHubContext<SignalRHub> hubContext, IProductService productService, UserManager<AppUser> userManager, IUserAdresService userAdresService, IDeliveryTimeService deliveryTimeService)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _hubContext = hubContext;
            _productService = productService;
            _userManager = userManager;
            _userAdresService = userAdresService;
            _deliveryTimeService = deliveryTimeService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult OrderList([FromQuery] FilteredOrderParamaters filteredParamaters)
        {
          
            var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).OrderByDescending(x => x.CreatedDate).ToList();
            //var result = _mapper.Map<List<ResultOrderVM>>(values);

            if (!string.IsNullOrEmpty(filteredParamaters.OrderStatus))
            {
                values = values.Where(x => x.OrderStatus.Contains(filteredParamaters.OrderStatus)).ToList();
            }

            var totalCount = values.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);

            values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize).ToList();

            var orders = _mapper.Map<List<ResultOrderVM>>(values).ToList();
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Orders = orders });
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
                OrderStatus = "Onay Bekliyor",

                AlternatifUrun = createOrderRequestVM.AlternatifUrun,
                TeslimatYontemi = createOrderRequestVM.TeslimatYontemi,
                TeslimatSaati = _deliveryTimeService.TGetByID(int.Parse(createOrderRequestVM.TeslimatSaati)).CreatedDate.ToString("dd-MMM-yyyy HH:mm") + " - " + _deliveryTimeService.TGetByID(int.Parse(createOrderRequestVM.TeslimatSaati)).EndTime.ToString("dd-MMM-yyyy HH:mm"),

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
            await _hubContext.Clients.All.SendAsync("ReceiveOrderNotification", "Yeni Siparişiniz Var");
            var resultCreateOrder = _mapper.Map<ResultOrderVM>(_OrderService.TGetByID(value.ID));
            await _hubContext.Clients.All.SendAsync("ReceiveOrder", resultCreateOrder);
            return Ok("Order Eklendi");
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product)
            .Where(x => x.ID == id).SingleOrDefault();
            var result = _mapper.Map<ResultOrderVM>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult OrderStatusOnay(int id)
        {
            _OrderService.UpdateOrderStatus(id, "Sipariş Onaylandı");
            return Ok("Sipariş Onaylandı olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult OrderStatusIptal(int id)
        {
            _OrderService.UpdateOrderStatus(id, "İptal Edildi");
            return Ok("Sipariş İptal Edildi olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult OrderStatusHazirlama(int id)
        {
            _OrderService.UpdateOrderStatus(id, "Hazırlanıyor");
            return Ok("Sipariş Hazirlanıyor olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult OrderStatusYolda(int id)
        {
            _OrderService.UpdateOrderStatus(id, "Yolda");
            return Ok("Sipariş Yolda olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public IActionResult OrderStatusTeslim(int id)
        {
            var order = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.ID == id).SingleOrDefault();
            if (order == null)
            {
                return NotFound("sipariş bulunamadı");    
            }
            var orderproducts = order?.OrderDetails;
            if (orderproducts != null)
            {
                foreach (var item in orderproducts)
                {
                    item.Product.Stock = item.Product.Stock - (int)Math.Floor(item.Count);
                }
            }
            else
            {
                return NotFound("siparişin detayları bulunamadı");
            }
            _OrderService.UpdateOrderStatus(id, "Teslim Edildi");
            return Ok("Sipariş Teslim Edildi olarak değiştirildi");
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> ListUserOrder()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.AppUserID == user.Id).ToList();
                var result = _mapper.Map<List<ResultOrderVM>>(values);
                return Ok(result);
            }
            return NotFound("Kullanici Bulunamadi");
        }

        [Authorize]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetUserOrder(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var values = _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .Where(x => x.ID == id && x.AppUserID == user.Id).SingleOrDefault();
                var result = _mapper.Map<ResultOrderVM>(values);
                return Ok(result);
            }
            return NotFound("Kullanici Bulunamadi");
        }


    }
}
