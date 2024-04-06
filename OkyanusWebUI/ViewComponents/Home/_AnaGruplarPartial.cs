using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _AnaGruplarPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
