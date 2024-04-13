using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAdresVM;
using OkyanusWebUI.Service;
using System.Reflection;

namespace OkyanusWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserAdresController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public UserAdresController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUserAdres()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAdres(CreateUserAdresVM model)
        {
            var responseMessage = await _customHttpClient.Post<CreateUserAdresVM>(new() { Controller = "UserAdres" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteUserAdres(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "UserAdres" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserAdres(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAdres" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserAdresVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAdres(UpdateUserAdresVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateUserAdresVM>(new() { Controller = "UserAdres" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSelectedUserAdres(int id)
        {
            var responseMessage = await _customHttpClient.Put<int>(new() { Controller = "UserAdres", Action = "UpdateSelectedUserAdres" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                //_notyfService.Success("Adresiniz Seçildi!");
                //return RedirectToAction("Index", "Order", new {area= "" });
                return Ok("Adres Güncellendi");
            }
            else
            {
                //_notyfService.Error("Adresiniz yoksa lütfen adres ekleyiniz!");
                //return RedirectToAction("Index");
                return NotFound("Adres Güncellenirken hata oluştu");
            }
        }


    }
}
