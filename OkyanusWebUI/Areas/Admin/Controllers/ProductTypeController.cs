using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductTypeVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypeController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public ProductTypeController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "ProductType" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductTypeVM>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddProductType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductType(CreateProductTypeVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateProductTypeVM>(new() { Controller = "ProductType" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProductType(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "ProductType" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductType(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "ProductType" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductTypeVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductType(UpdateProductTypeVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateProductTypeVM>(new() { Controller = "ProductType" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
