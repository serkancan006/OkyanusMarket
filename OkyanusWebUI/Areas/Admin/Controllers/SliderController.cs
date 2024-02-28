using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.SliderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly FileOperationService _fileOperationService;
        public SliderController(CustomHttpClient customHttpClient, FileOperationService fileOperationService)
        {
            _customHttpClient = customHttpClient;
            _fileOperationService = fileOperationService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Slider" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSlider()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSlider(IFormFile file, string description)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var (fileName,databasePath) = await _fileOperationService.SaveFileAsync(file, "images/Slider/");
            CreateSliderVM model = new CreateSliderVM()
            {
                Description = description,
                ImageUrl = databasePath,
            };
            var responseMessage = await _customHttpClient.Post<CreateSliderVM>(new() { Controller = "Slider" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "Slider" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var oldProductImage = await responseMessage.Content.ReadAsStringAsync();
                //Console.WriteLine(oldProductImage);
                if (oldProductImage != null)
                {
                    _fileOperationService.DeleteFile(oldProductImage);
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SliderDetails(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Slider" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultSliderVM>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
