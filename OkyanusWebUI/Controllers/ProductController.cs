using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
