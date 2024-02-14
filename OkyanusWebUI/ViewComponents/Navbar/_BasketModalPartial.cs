using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Navbar
{
    public class _BasketModalPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly BasketService _basketService;

        public _BasketModalPartial(CustomHttpClient customHttpClient, BasketService basketService)
        {
            _customHttpClient = customHttpClient;
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _basketService.GetItems();
            var totalPrice = _basketService.GetTotalPrice();
            var totalItems = _basketService.GetTotalItems();

            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalItems = totalItems;

            return View(items);
        }
    }
}
