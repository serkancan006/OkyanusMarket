using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Order
{
    public class _OrderSummaryPartial : ViewComponent
    {
        private readonly BasketService _basketService;

        public _OrderSummaryPartial(BasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CartItem> value = _basketService.Items.ToList();
            ViewBag.OrderTotalPrice = _basketService.GetTotalPrice();
            return View(value);
        }
    }
}
