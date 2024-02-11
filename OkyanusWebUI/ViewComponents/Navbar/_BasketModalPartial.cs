using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Navbar
{
    public class _BasketModalPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;

        public _BasketModalPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
