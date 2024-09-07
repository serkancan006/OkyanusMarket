using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.FavoriUrunlerVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.User.Controllers
{
    [Authorize]
    [Area("User")]
    public class FavoriUrunlerController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public FavoriUrunlerController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "FavoriUrunler" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFavoriUrunlerVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> AddFavoriUrunler(string id)
        {
            CreateFavoriUrunlerVM favoriurun = new CreateFavoriUrunlerVM();
            favoriurun.ProductID = id;
            var responseMessage = await _customHttpClient.Post<CreateFavoriUrunlerVM>(new() { Controller = "FavoriUrunler" }, favoriurun);
            if (responseMessage.IsSuccessStatusCode)
                return Ok("Favoriye Eklendi!");
            else
                return BadRequest("Favoriye Eklenemedi!");
        }

        public async Task<IActionResult> DeleteFavoriUrunler(string id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "FavoriUrunler" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Success("Favorilerden Silindi!");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error("Favorilerden Silinemedi!");
                return RedirectToAction("Index");
            }
        }



    }
}
