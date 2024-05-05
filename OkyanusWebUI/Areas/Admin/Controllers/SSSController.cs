using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.SssVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SSSController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public SSSController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "SSS" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSssVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddSSS()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSSS(CreateSssVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateSssVM>(new() { Controller = "SSS" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSSS(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "SSS" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSSS(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "SSS" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSssVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSSS(UpdateSssVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateSssVM>(new() { Controller = "SSS" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
