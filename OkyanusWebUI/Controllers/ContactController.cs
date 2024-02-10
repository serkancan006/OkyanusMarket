using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ContactMessageVM;
using OkyanusWebUI.Models.ContactVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public ContactController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Contact" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContactMessage(CreateContactMessageVM model)
        {
            if (!ModelState.IsValid)
            {
                _notyfService.Error("Lütfen tüm alanları doldurunuz.");
                return RedirectToAction("Index");
            }

            var responseMessage = await _customHttpClient.Post<CreateContactMessageVM>(new() { Controller = "ContactMessage" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Mesajınız Gönderildi. Yetkililerimiz en kısa sürede iletişime geçicektir.");
                return RedirectToAction("Index");
            }
            _notyfService.Error("Mesajınız gönderilirken bir hata oluştu.");
            return RedirectToAction("Index");
        }

    }
}
