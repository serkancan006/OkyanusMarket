using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Controllers
{
    public class _LayoutController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly BasketService _basketService;

        public _LayoutController(CustomHttpClient customHttpClient, BasketService basketService)
        {
            _customHttpClient = customHttpClient;
            _basketService = basketService;
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            var items = _basketService.GetItems();
            var totalPrice = _basketService.GetTotalPrice();
            var totalItems = _basketService.GetTotalItems();

            ViewBag.TotalPrice = totalPrice;
            ViewBag.TotalItems = totalItems;

            return PartialView(items);
        }

        public PartialViewResult VideoPlayerPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
