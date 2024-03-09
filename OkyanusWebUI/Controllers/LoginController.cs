using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OkyanusWebUI.Service;
using OkyanusWebUI.Models.LoginVM;
using System.Text;
using System.Web;
using System.Reflection;

namespace OkyanusWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        private readonly TokenService _tokenService;
        public LoginController(CustomHttpClient customHttpClient, INotyfService notyfService, TokenService tokenService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var responseMessage = await _customHttpClient.Post<LoginUserVM>(new() { Controller = "Login" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<JObject>(responseContent);
                var token = responseObject?["value"]?["token"]?.ToString();
                var expires = responseObject?["value"]?["expires"]?.ToString();
                _tokenService.SetToken(token, expires);
                _notyfService.Success("Kullanıcı Girişi Başarılı");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Hata durumunda konsola hataları yazdırma
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                var errorObject = JsonConvert.DeserializeObject<JObject>(errorContent);
                var errorMessage = errorObject?["message"]?.ToString();
                //Console.WriteLine($"Hata Mesajı: {errorMessage}");
                _notyfService.Error(errorMessage);
                return View();
            }
            //return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string Email)
        {
            var responseMessage = await _customHttpClient.Post(new() { Controller = "Login", Action = "ForgotPassword" }, Email);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Mail adresinize link gönderilmiştir!");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error("Bir hata oluştu. Tekrar Deneyin!");
                return View();
            }
        }

        public IActionResult ResetPassword(string userEmail, string token)
        {
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(token)));
            //Console.WriteLine(decodedToken);
            ResetPasswordVM resetPasswordVM = new ResetPasswordVM()
            {
                Email = userEmail,
                ResetToken = decodedToken
            };
            return View(resetPasswordVM);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            ResetPasswordVMApi resetPasswordVMApi = new ResetPasswordVMApi()
            {
                NewPassword = model.NewPassword,
                Email = model.Email,
                ResetToken = model.ResetToken
            };
            var responseMessage = await _customHttpClient.Post(new() { Controller = "Login", Action = "ResetPassword" }, resetPasswordVMApi);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public async Task<IActionResult> EMailConfirm(string userEmail, string token)
        {
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(HttpUtility.UrlDecode(token)));
            //Console.WriteLine(decodedToken);
            EMailConfirmVM eMailConfirmVM = new EMailConfirmVM()
            {
                Email = userEmail,
                ConfirmToken = decodedToken
            };
            var responseMessage = await _customHttpClient.Post(new() { Controller = "Login", Action = "EMailConfirm" }, eMailConfirmVM);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View(true);
            }
            else
            {
                return View(false);
            }
        }

        public IActionResult LogOut()
        {
            _tokenService.ClearToken();
            _notyfService.Information("Çıkış Yapıldı!");
            return RedirectToAction("Index", "Home");
        }

    }

    public class ResetPasswordVMApi
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }

    public class ResetPasswordVM
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }

    public class EMailConfirmVM
    {
        public string Email { get; set; }
        public string ConfirmToken { get; set; }
    }

}
