using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Abstract.ExternalService;
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
        private readonly IMailService _mailService;

        public OrderController(IOrderService OrderService, IMapper mapper, IOrderDetailService orderDetailService, IHubContext<SignalRHub> hubContext, IProductService productService, UserManager<AppUser> userManager, IUserAdresService userAdresService, IDeliveryTimeService deliveryTimeService, IMailService mailService)
        {
            _OrderService = OrderService;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _hubContext = hubContext;
            _productService = productService;
            _userManager = userManager;
            _userAdresService = userAdresService;
            _deliveryTimeService = deliveryTimeService;
            _mailService = mailService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> OrderList([FromQuery] FilteredOrderParamaters filteredParamaters)
        {
            var values = _OrderService.TAsQueryable();
            //.Include(x => x.OrderDetails).ThenInclude(x => x.Product);
            //.OrderByDescending(x => x.CreatedDate);

            if (!string.IsNullOrEmpty(filteredParamaters.OrderStatus))
            {
                values = values.Where(x => x.OrderStatus.Contains(filteredParamaters.OrderStatus));
            }

            var totalCount = await values.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / filteredParamaters.pageSize);
            values = values.Include(x => x.OrderDetails).ThenInclude(x => x.Product).OrderByDescending(x => x.CreatedDate);
            values = values.Skip((filteredParamaters.pageNumber - 1) * filteredParamaters.pageSize).Take(filteredParamaters.pageSize); //sıkıntı olursa .ToListAsync ekle. veya              var product = await _mapper.ProjectTo<ResultProductVM>(values).ToListAsync(); gibi  kullanabilirsin.

            var orders = _mapper.Map<List<ResultOrderVM>>(values);
            return Ok(new { TotalCount = totalCount, TotalPages = totalPages, Orders = orders });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var values = await _OrderService.TGetByIDAsync(id);
            await _OrderService.TDeleteAsync(values);
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
        public async Task<IActionResult> GetOrder(int id)
        {
            var values = await _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).ThenInclude(x => x.Marka)
            .Where(x => x.ID == id).SingleOrDefaultAsync();
            var result = _mapper.Map<ResultOrderVM>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderStatusOnay(int id)
        {
            await _OrderService.UpdateOrderStatusAsync(id, "Sipariş Onaylandı");
            //var order = await _OrderService.TGetByIDAsync(id);
            //await _mailService.SendMailAsync($"{order.OrderFirstName} {order.OrderSurname}", order.OrderMail, "Siparişiniz Onaylandı", "Siparişiniz Onaylanmıştır");
            return Ok("Sipariş Onaylandı olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderStatusIptal(int id)
        {
            await _OrderService.UpdateOrderStatusAsync(id, "İptal Edildi");
            return Ok("Sipariş İptal Edildi olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderStatusHazirlama(int id)
        {
            await _OrderService.UpdateOrderStatusAsync(id, "Hazırlanıyor");
            return Ok("Sipariş Hazirlanıyor olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderStatusYolda(int id)
        {
            await _OrderService.UpdateOrderStatusAsync(id, "Yolda");
            return Ok("Sipariş Yolda olarak değiştirildi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> OrderStatusTeslim(int id)
        {
            await _OrderService.UpdateOrderStatusAsync(id, "Teslim Edildi");
            //var order = await _OrderService.TGetByIDAsync(id);
            //await _mailService.SendMailAsync($"{order.OrderFirstName} {order.OrderSurname}", order.OrderMail, "Siparişiniz Teslim Edildi", "Siparişiniz Edilmiştir. Bizi tercih ettiğiniz için teşekkür ederiz!");
            return Ok("Sipariş Teslim Edildi olarak değiştirildi");
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> ListUserOrder()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var values = await _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.AppUserID == user.Id).OrderByDescending(x => x.CreatedDate).ToListAsync();
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
                var values = await _OrderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .Where(x => x.ID == id && x.AppUserID == user.Id).SingleOrDefaultAsync();
                var result = _mapper.Map<ResultOrderVM>(values);
                return Ok(result);
            }
            return NotFound("Kullanici Bulunamadi");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateOrderRequestVM createOrderRequestVM)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var adres = await _userAdresService.TGetByIDAsync(createOrderRequestVM.UserAdresID);
            //var deliveryTime = await _deliveryTimeService.TGetByIDAsync(int.Parse(createOrderRequestVM.TeslimatSaati));

            var createOrderVM = new CreateOrderVM()
            {
                Description = createOrderRequestVM.Description,
                OrderStatus = "Onay Bekliyor",

                AlternatifUrun = createOrderRequestVM.AlternatifUrun,
                TeslimatYontemi = createOrderRequestVM.TeslimatYontemi,
                OrderPaymentType = createOrderRequestVM.OrderPaymentType,
                //TeslimatSaati = deliveryTime.StartedTime.ToString("hh\\:mm") + " - " + deliveryTime.EndTime.ToString("hh\\:mm"),
                TeslimatSaati = createOrderRequestVM.TeslimatSaati,

                OrderPhone = createOrderRequestVM.TelefonNo, // Değiştirildi

                OrderAdress = adres.UserAdress,
                OrderApartman = adres.UserApartman,
                OrderDaire = adres.UserDaire,
                OrderKat = adres.UserKat,
                OrderIlce = adres.UserIlce,
                OrderSehir = adres.UserSehir,
            };

            var totalPrice = createOrderRequestVM.OrderItems.Sum(x =>
            {
                var product = _productService.TGetByIDAsync(x.ProductId.ToString()).Result;
                return (product.DiscountedPrice ?? product.Price) * x.Quantity;
            });

            createOrderVM.TotalPrice = totalPrice;

            var value = _mapper.Map<Order>(createOrderVM);
            value.OrderSurname = user.Surname;
            value.OrderFirstName = user.Name;
            //value.OrderUserPhone = user.PhoneNumber;
            value.OrderMail = user.Email;
            value.AppUserID = user.Id;
            await _OrderService.TAddAsync(value);

            var createOrderDetailVM = createOrderRequestVM.OrderItems.Select(item => new CreateOrderDetailVM()
            {
                ProductID = item.ProductId,
                Count = item.Quantity,
                UnitPrice = _productService.TGetByIDAsync(item.ProductId.ToString()).Result.DiscountedPrice ?? _productService.TGetByIDAsync(item.ProductId.ToString()).Result.Price,
                OrderID = value.ID,
            }).ToList();

            var orderItemList = _mapper.Map<List<OrderDetail>>(createOrderDetailVM);
            await _orderDetailService.TAddRangeAsync(orderItemList);

            await _hubContext.Clients.All.SendAsync("ReceiveOrderNotification", "Yeni Siparişiniz Var");
            var resultCreateOrder = _mapper.Map<ResultOrderVM>(await _OrderService.TGetByIDAsync(value.ID));
            await _hubContext.Clients.All.SendAsync("ReceiveOrder", resultCreateOrder);

            return Ok("Order Eklendi");
        }

    }
}
