using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
