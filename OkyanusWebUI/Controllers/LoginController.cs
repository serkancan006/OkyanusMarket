using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
