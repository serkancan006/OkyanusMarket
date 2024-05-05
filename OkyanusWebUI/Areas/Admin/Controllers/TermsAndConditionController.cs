using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.TermsAndConditionVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TermsAndConditionController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public TermsAndConditionController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "TermsAndCondition" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTermsAndConditionVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddTermsAndCondition()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTermsAndCondition(CreateTermsAndConditionVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateTermsAndConditionVM>(new() { Controller = "TermsAndCondition" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteTermsAndCondition(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "TermsAndCondition" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTermsAndCondition(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "TermsAndCondition" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateTermsAndConditionVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTermsAndCondition(UpdateTermsAndConditionVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateTermsAndConditionVM>(new() { Controller = "TermsAndCondition" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
