using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.DeliveryTimeVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeliveryTimesController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public DeliveryTimesController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "DeliveryTime" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDeliveryTimeVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> LastDeliveryTimeList()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "DeliveryTime", Action= "LastDeliveryTimeList" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultDeliveryTimeVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddDeliveryTime()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDeliveryTime(CreateDeliveryTimeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateDeliveryTimeVM>(new() { Controller = "DeliveryTime" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteDeliveryTime(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "DeliveryTime" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDeliveryTime(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "DeliveryTime" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateDeliveryTimeVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDeliveryTime(UpdateDeliveryTimeVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateDeliveryTimeVM>(new() { Controller = "DeliveryTime" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
