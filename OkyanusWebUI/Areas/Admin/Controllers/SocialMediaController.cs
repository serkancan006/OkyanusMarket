using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.SocialMediaVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public SocialMediaController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "SocialMedia" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult AddSocialMedia()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddSocialMedia(CreateSocialMediaVM model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }
        //    var responseMessage = await _customHttpClient.Post<CreateSocialMediaVM>(new() { Controller = "SocialMedia" }, model);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //public async Task<IActionResult> DeleteSocialMedia(int id)
        //{
        //    var responseMessage = await _customHttpClient.Delete(new() { Controller = "SocialMedia" }, id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "SocialMedia" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateSocialMediaVM>(new() { Controller = "SocialMedia" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
