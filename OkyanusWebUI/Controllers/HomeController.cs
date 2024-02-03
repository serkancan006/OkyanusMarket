using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
