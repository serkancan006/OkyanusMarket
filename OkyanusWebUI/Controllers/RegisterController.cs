using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.RegisterVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public RegisterController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var responseMessage = await _customHttpClient.Post<RegisterUserVM>(new() { Controller = "Register" }, model);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Login");
            else
            {
                // Hata durumunda konsola hataları yazdırma
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine($"HTTP Hata Kodu: {responseMessage.StatusCode}");
                Console.WriteLine($"Hata Detayları: {errorContent}");
                var errors = JsonConvert.DeserializeObject<List<IdentityError>>(errorContent);
                foreach (var error in errors ?? Enumerable.Empty<IdentityError>())
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

        }
    }
}
