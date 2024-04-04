using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OkyanusWebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int code)
        {
            string errorMessage;
            switch (code)
            {
                case (int)HttpStatusCode.BadRequest:
                    errorMessage = "Hatalı işlem!";
                    break;
                case (int)HttpStatusCode.Unauthorized:
                    //errorMessage = "Yetkisiz işlem. Lütfen giriş yapınız!";
                    //break;
                    return RedirectToAction("Index", "Login");
                case (int)HttpStatusCode.Forbidden:
                    errorMessage = "Erişim Yetkiniz yok!";
                    break;
                //case (int)HttpStatusCode.NotFound:
                case 404:
                    errorMessage = "Sayfa Bulunamadı!";
                    break;
                case (int)HttpStatusCode.InternalServerError:
                    errorMessage = "Sunucu Hatası oluştu!";
                    break;
                default:
                    errorMessage = "Hata!";
                    break;
            }

            ViewBag.ErrorPageMessage = errorMessage;
            return View(code);
        }
    }
}
