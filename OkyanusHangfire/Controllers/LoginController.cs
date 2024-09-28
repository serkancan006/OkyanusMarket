using Microsoft.AspNetCore.Mvc;

namespace OkyanusHangfire.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // Basit bir kullanıcı adı ve şifre kontrolü
            if (username == _configuration["HangFireAuth:username"] && password == _configuration["HangFireAuth:password"])
            {
                // Kullanıcıyı oturum açmış olarak işaretleyin
                HttpContext.Session.SetString("HangfireUser", username);
                return Redirect("/hangfire");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("HangfireUser");
            return RedirectToAction("Index");
        }
    }
}
