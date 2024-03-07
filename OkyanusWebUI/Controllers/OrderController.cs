using AspNetCoreHero.ToastNotification.Abstractions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;
using OkyanusWebUI.Validations;
using System.Reflection;

namespace OkyanusWebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly CustomHttpClient _customHttpClient;
        private readonly BasketService _basketService;
        private readonly INotyfService _notyfService;
        public OrderController(TokenService tokenService, CustomHttpClient customHttpClient, BasketService basketService, INotyfService notyfService)
        {
            _tokenService = tokenService;
            _customHttpClient = customHttpClient;
            _basketService = basketService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderVM createOrderVM)
        {
            createOrderVM.OrderItems = _basketService.Items.ToList();
            createOrderVM.TotalPrice = _basketService.GetTotalPrice();
            CreateOrderValidator validator = new CreateOrderValidator();
            ValidationResult results = validator.Validate(createOrderVM);
            if (results.IsValid)
            {
                var responseMessage = await _customHttpClient.Post<CreateOrderVM>(new() { Controller = "Order" }, createOrderVM);
                if (responseMessage.IsSuccessStatusCode)
                {
                    _basketService.ClearCart();
                    _notyfService.Success("Siparişiniz başarılı bir şekilde oluşturuldu.");
                    return View();
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _notyfService.Warning("Sipariş Oluşturulurken hata oluştu!");
                return View();
            }
            _notyfService.Error("Sipariş Oluşturulurken hata oluştu!");
            return View(createOrderVM);
        }

    }
}
