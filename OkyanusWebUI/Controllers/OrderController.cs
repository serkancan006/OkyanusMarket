using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.OrderVM;
using OkyanusWebUI.Service;
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

        public async Task<IActionResult> Index()
        {
            CreateOrderVM createOrder = new CreateOrderVM();
            createOrder.OrderItems = _basketService.Items.ToList();
            createOrder.TotalPrice = _basketService.GetTotalPrice();
            bool result = _tokenService.IsAuthonticate();
            if (result)
            {
                var responseMessage = await _customHttpClient.Get(new() { Controller = "Users", Action = "GetUserInfoForOrder" });
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultGetUserInfoForOrder>(jsonData);
                    createOrder.OrderFirstName = values.FirstName;
                    createOrder.OrderSurname = values.SurName;
                    createOrder.OrderMail = values.Email;
                    createOrder.OrderPhone = values.PhoneNumber;
                    return View(createOrder);
                }
            }
            return View(createOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderVM createOrderVM)
        {
            createOrderVM.OrderItems = _basketService.Items.ToList();
            createOrderVM.TotalPrice = _basketService.GetTotalPrice();
            if (!ModelState.IsValid)
            {
                //foreach (var modelStateEntry in ModelState.Values)
                //{
                //    foreach (var error in modelStateEntry.Errors)
                //    {
                //        var errorMessage = error.ErrorMessage;
                //        Console.WriteLine(errorMessage);
                //    }
                //}
                return View(createOrderVM);
            }
            var responseMessage = await _customHttpClient.Post<CreateOrderVM>(new() { Controller = "Order" }, createOrderVM );
            if (responseMessage.IsSuccessStatusCode)
            {
                _basketService.ClearCart();
                _notyfService.Success("Siparişiniz başarılı bir şekilde oluşturuldu.");
                return RedirectToAction("Index");
            }
            _notyfService.Error("Sipariş Oluşturulurken hata oluştu!");
            return View();
        }

    }
}
