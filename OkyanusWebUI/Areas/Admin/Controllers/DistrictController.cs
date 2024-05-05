using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.DistrictVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DistrictController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly CityService _cityService;
        private readonly INotyfService _notyfService;
        public DistrictController(CustomHttpClient customHttpClient, CityService cityService, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _cityService = cityService;
            _notyfService = notyfService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            //id değeri city id den geliyor
            var responseMessage = await _customHttpClient.Get(new() { Controller = "District" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDistrictVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddDistrict()
        {
            ViewBag.UserSehirItems = await _cityService.GetCityList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDistrict(CreateDistrictVM model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            ViewBag.UserSehirItems = await _cityService.GetCityList();
            var responseMessage = await _customHttpClient.Post<CreateDistrictVM>(new() { Controller = "District" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("İlçe Eklendi!", 5);
                return RedirectToAction("Index", "City");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "District" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("İlçe Silindi!", 5);
                return RedirectToAction("Index", "City");
            }
            else
            {
                _notyfService.Error("İlçe Silinemedi!", 5);
                return RedirectToAction("Index", "City");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDistrict(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "District", Action= "GetDistrict" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDistrictVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDistrict(UpdateDistrictVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateDistrictVM>(new() { Controller = "District" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("İlçe Güncellendi!", 5);
                return RedirectToAction("Index", "City");
            }
            return View();
        }
    }
}
