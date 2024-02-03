using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _ProductPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
