using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            if (!ModelState.IsValid)
            {
                //_notyfService.Error("Lütfen tüm alanları doldurunuz.");
                string errormesaj = "";
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    errormesaj += error.ErrorMessage + "</br>";
                }
                _notyfService.Error(errormesaj, 10);
                return RedirectToAction("Index");
            }
            var apiModel = new UpdateUserAccountVM()
            {
                UserFirstName = model.UserFirstName,
                //UserPhoneNumber = model.UserPhoneNumber,
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
            if (!ModelState.IsValid)
            {
                //_notyfService.Error("Lütfen tüm alanları doldurunuz.");
                string errormesaj = "";
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    errormesaj += error.ErrorMessage + "</br>";
                }
                _notyfService.Error(errormesaj, 10);
                return RedirectToAction("Index");
            }
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
