using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _ProductModalPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
