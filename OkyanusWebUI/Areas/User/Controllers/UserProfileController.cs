using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Areas.User.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
