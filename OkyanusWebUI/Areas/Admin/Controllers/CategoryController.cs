using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Areas.Admin.Models.AdminGroupVM;
using OkyanusWebUI.Models.CategoryVM;
using OkyanusWebUI.Models.GroupVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly FileOperationService _fileOperationService;
        public CategoryController(CustomHttpClient customHttpClient, FileOperationService fileOperationService)
        {
            _customHttpClient = customHttpClient;
            _fileOperationService = fileOperationService;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Group" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGroupVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateGroupVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateGroupVM>(new() { Controller = "Group" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(string id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "Group" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Group" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGroupVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateGroupVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateGroupVM>(new() { Controller = "Group" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult changeImageGroup(string id)
        {
            return ViewComponent("ChangeGroupImagePartial", new { categoryName = id });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImageGroup(ChangeCategoryImageRequest request)
        {
            if (request.FormFile == null)
            {
                var changeImageRequestApi = new ChangeGroupImageApiRequest
                {
                    CategoryName = request.CategoryName,
                    ImagePath = null
                };

                var responseMessage = await _customHttpClient.Post<ChangeGroupImageApiRequest>(
                    new() { Controller = "Group", Action = "ChangeGroupImage" },
                    changeImageRequestApi
                );

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
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                var (fileName, databasePath) = await _fileOperationService.SaveFileAsync(request.FormFile, "images/group/");

                var changeImageRequestApi = new ChangeGroupImageApiRequest
                {
                    CategoryName = request.CategoryName,
                    ImagePath = databasePath
                };

                var responseMessage = await _customHttpClient.Post<ChangeGroupImageApiRequest>(
                    new() { Controller = "Group", Action = "ChangeGroupImage" },
                    changeImageRequestApi
                );

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
                else
                {
                    // Hata durumunda dosyayı silme işlemi
                    _fileOperationService.DeleteFile(databasePath);
                    return BadRequest();
                }
            }

        }
        private class ChangeGroupImageApiRequest
        {
            public string? ImagePath { get; set; }
            public string CategoryName { get; set; }
        }
    }
}
