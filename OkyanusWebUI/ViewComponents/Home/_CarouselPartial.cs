using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _CarouselPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
