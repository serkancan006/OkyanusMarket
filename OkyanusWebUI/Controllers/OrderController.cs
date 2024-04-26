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
        public OrderController(TokenService tokenService, CustomHttpClient customHttpClient, BasketService basketService, INotyfService notyfService)
        {
            _tokenService = tokenService;
            _customHttpClient = customHttpClient;
            _basketService = basketService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Value = "0", Text = "Adres Ekle" });
            foreach (var value in values)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.UserAdress
                };
                selectListItems.Add(item);
            }
            ViewBag.SelectListItems = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderVM createOrderVM)
        {
            //createOrderVM.OrderItems = _basketService.Items.ToList();
            //createOrderVM.TotalPrice = _basketService.GetTotalPrice();
            var responseMessage2 = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData2);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Value = "0", Text = "Adres Ekle" });
            foreach (var value in values2)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.UserAdress
                };
                selectListItems.Add(item);
            }
            ViewBag.SelectListItems = selectListItems;
            //CreateOrderValidator validator = new CreateOrderValidator();
            //ValidationResult results = validator.Validate(createOrderVM);
            if (!ModelState.IsValid)
            {
                _notyfService.Warning("Veriler Geçersiz!");
                return View(createOrderVM);
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
                return RedirectToAction("Index","Home");
            }
            else
            {
                _notyfService.Error("Sipariş Oluşturulurken hata oluştu!");
                return View(createOrderVM);
            }
       
        }

    }
}
