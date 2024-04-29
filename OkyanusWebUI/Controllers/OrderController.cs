using AspNetCoreHero.ToastNotification.Abstractions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Models.UserAdresVM;
using OkyanusWebUI.Service;
using OkyanusWebUI.Validations;
using System.Reflection;

namespace OkyanusWebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly CustomHttpClient _customHttpClient;
        private readonly BasketService _basketService;
        private readonly INotyfService _notyfService;
        private readonly UserAdresService _userAdresService;
        private readonly DeliveryTimeService _deliveryTimeService;
        public OrderController(TokenService tokenService, CustomHttpClient customHttpClient, BasketService basketService, INotyfService notyfService, UserAdresService userAdresService, DeliveryTimeService deliveryTimeService)
        {
            _tokenService = tokenService;
            _customHttpClient = customHttpClient;
            _basketService = basketService;
            _notyfService = notyfService;
            _userAdresService = userAdresService;
            _deliveryTimeService = deliveryTimeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.SelectListItems = await _userAdresService.GetUserAdres();
            ViewBag.DeliveryTimeItems = await _deliveryTimeService.GetDeliveryTimeList();
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index(CreateOrderVM createOrderVM)
        //{
        //  CreateOrderValidator validator = new CreateOrderValidator();
        //  ValidationResult results = validator.Validate(createOrderVM);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderVM createOrderVM)
        {
            createOrderVM.OrderItems = _basketService.Items.ToList();
            createOrderVM.TotalPrice = _basketService.GetTotalPrice();
            ViewBag.SelectListItems = await _userAdresService.GetUserAdres();
            ViewBag.DeliveryTimeItems = await _deliveryTimeService.GetDeliveryTimeList();

            ModelState.Clear();
            TryValidateModel(createOrderVM);
            if (!ModelState.IsValid)
            {
                _notyfService.Warning("Veriler Geçersiz!");
                return View();
            }

            CreateOrderVmApi createOrderVmApi = new CreateOrderVmApi()
            {
                alternatifUrun = createOrderVM.AlternatifUrun,
                description = createOrderVM.Description,
                telefonNo = createOrderVM.TelefonNo,
                teslimatSaati = createOrderVM.TeslimatSaati,
                teslimatYontemi = createOrderVM.TeslimatYontemi,
                userAdresID = createOrderVM.UserAdresID,
                orderItems = createOrderVM.OrderItems.Select(item => new CreateOrderVmApi.Orderitem
                {
                    productId = item.ProductId,
                    quantity = item.Quantity
                }).ToList()
            };

            var responseMessage = await _customHttpClient.Post<CreateOrderVmApi>(new() { Controller = "Order" }, createOrderVmApi);
            if (responseMessage.IsSuccessStatusCode)
            {
                _basketService.ClearCart();
                _notyfService.Success("Siparişiniz başarılı bir şekilde oluşturuldu.");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _notyfService.Error("Sipariş Oluşturulurken hata oluştu!");
                return View(createOrderVM);
            }

        }

    }
}
