using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.ViewComponents.Product
{
    public class _ProductSidebarPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
