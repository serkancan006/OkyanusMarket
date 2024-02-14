using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

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


        //public async Task<IActionResult> AddBasketItem(int id)
        //{
        //    var responseMessage = await _customHttpClient.Get(new() { Controller = "Product" }, id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<ResultProductVM>(jsonData);
        //        if (values != null)
        //        {
        //            CartItem cartItem = new CartItem()
        //            {
        //                ImageUrl = values.ImageUrl,
        //                Name = values.ProductName,
        //                Price = values.DiscountedPrice ?? values.Price,
        //                ProductId = values.ID,
        //                Quantity = 1
        //            };
        //            _basketService.AddItem(cartItem);
        //        }
        //    }
        //    return Redirect(Request.Headers["Referer"].ToString());
        //}



    }
}
