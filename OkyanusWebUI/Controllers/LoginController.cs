﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OkyanusWebUI.Service;
using OkyanusWebUI.Models.LoginVM;

namespace OkyanusWebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public LoginController(CustomHttpClient customHttpClient, INotyfService notyfService)
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
                var existingToken = HttpContext.Request.Cookies["Token"];
                var existingExpires = HttpContext.Request.Cookies["TokenExpires"];
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
    }
}
