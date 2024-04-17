using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAccountVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class UserProfileController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public UserProfileController(CustomHttpClient customHttpClient, INotyfService notyfService)
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
        public async Task<IActionResult> UpdateUserAccount(ResultUserAccountVM model)
        {
            var apiModel = new UpdateUserAccountVM()
            {
                UserFirstName = model.UserFirstName,
                UserPhoneNumber = model.UserPhoneNumber,
                UserSurname = model.UserSurname
            };
            var responseMessage = await _customHttpClient.Post(new() { Controller = "UserAccount" }, apiModel);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Değişiklikler kaydedildi");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error("Bir hata meydana geldi.");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            var modelApi = new ChangePasswordVMApi()
            {
                CurrentPassword = model.CurrentPassword,
                NewPassword = model.NewPassword,
            };
            var responseMessage = await _customHttpClient.Post(new() { Controller = "UserAccount", Action = "ChangePassword" }, modelApi);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Şifre Değiştirildi");
                return RedirectToAction("Index");
            }
            else
            {
                var errorContent = await responseMessage.Content.ReadAsStringAsync();
                _notyfService.Error(errorContent);
                return RedirectToAction("Index");
            }
        }

    }
}
