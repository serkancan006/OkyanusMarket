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

        public async Task<IActionResult> AddBasketItem(int id)
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
                        Quantity = 1,
                        Birim = values.ProductType.Birim,
                        IncreaseAmount = values.ProductType.IncreaseAmount,
                    };
                    _basketService.AddItem(cartItem);
                    _notyfService.Success("sepete eklendi!");
                }
            }
            return Ok();
            //return ViewComponent("_BasketModalPartial");
            //return Redirect(Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        public IActionResult UpdateBasketItemQuantity(int id, string quantity, string birim)
        {
            //Console.WriteLine(birim);
            double convertQuantity = double.Parse(quantity.Replace(',', '.'), CultureInfo.InvariantCulture);
            if (convertQuantity <= 0)
            {
                return Ok();
            }
            if (birim == "Adet")
            {
                // Tam sayı kontrolü
                if (convertQuantity % 1 != 0)
                {
                    convertQuantity = (int)convertQuantity;
                }
            }
            _basketService.UpdateQuantity(id, convertQuantity);
            return Ok();
        }

        public IActionResult deleteBasketItem(int id)
        {
            _basketService.RemoveItem(id);
            return Ok();
        }

    }
}
