using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;
using System.Globalization;

namespace OkyanusWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly BasketService _basketService;
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public BasketController(BasketService basketService, CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _basketService = basketService;
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        public IActionResult GetBasketItems()
        {
            var items = _basketService.GetItems();
            var totalPrice = _basketService.GetTotalPrice();
            var totalItems = _basketService.GetTotalItems();
            return Json(new { items, totalPrice, totalItems });
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductVM>(jsonData);
                if (values != null)
                {
                    CartItem cartItem = new CartItem()
                    {
                        ImageUrl = values.ImageUrl,
                        Name = values.ProductName,
                        Price = values.DiscountedPrice ?? values.Price,
                        RealPrice = values.DiscountedPrice != null ? values.Price : null,
                        ProductId = values.ID,
                        Stock = values.Stock,
                        Quantity = 1, //gönderilecek miktar
                        Birim = values.ProductType.Birim,
                        IncreaseAmount = values.ProductType.IncreaseAmount,
                    };
                    _basketService.AddItem(cartItem);
                    _notyfService.Success("sepete eklendi!");
                }
            }
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateBasketItemQuantity(UpdateBasketQuantity model)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        errorMessage += error.ErrorMessage + "</br>";
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return BadRequest(errorMessage);
            }
            _basketService.UpdateQuantity(model.id.ToString(), model.quantity);
            return Ok();
        }

        public IActionResult deleteBasketItem(string id)
        {
            _basketService.RemoveItem(id.ToString());
            return Ok();
        }

    }
    public class UpdateBasketQuantity
    {
        public string id { get; set; }
        public decimal quantity { get; set; }
        public string birim { get; set; }
        public decimal stock { get; set; }
        public decimal increaseAmount { get; set; }
    }
}
