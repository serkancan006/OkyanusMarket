using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Areas.User.Controllers
{
    public class UserOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
