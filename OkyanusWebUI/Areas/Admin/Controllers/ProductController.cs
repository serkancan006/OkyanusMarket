using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public ProductController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IActionResult> Index([FromQuery] FilteredParameters filteredParameters)
        {
            var queryString = BuildQueryString(filteredParameters);

            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product", QueryString = queryString });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductListResponse>(jsonData);
                ViewBag.TotalPages = values?.TotalPages;
                ViewBag.PageNumber = filteredParameters.PageNumber;
                ViewBag.PageSize = filteredParameters.PageSize;
                ViewBag.SearchName = filteredParameters.SearchName;
                return View(values?.Product);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductVM model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var responseMessage = await _customHttpClient.Post<CreateProductVM>(new() { Controller = "Product" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "Product" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductVM>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductVM model)
        {
            var responseMessage = await _customHttpClient.Put<UpdateProductVM>(new() { Controller = "Product" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public class FilteredParameters
        {
            public string? SearchName { get; set; }
            public List<string>? CategoryNames { get; set; }
            public int? PageNumber { get; set; } = 1;
            public int? PageSize { get; set; } = 20;
        }

        private string BuildQueryString(FilteredParameters filteredParameters)
        {
            var queryString = "";

            if (filteredParameters.PageNumber != null && filteredParameters.PageSize != null)
            {
                queryString += $"pageNumber={filteredParameters.PageNumber}&pageSize={filteredParameters.PageSize}";
            }
            if (!string.IsNullOrEmpty(filteredParameters.SearchName))
            {
                queryString += $"&searchName={filteredParameters.SearchName}";
            }

            if (filteredParameters.CategoryNames != null && filteredParameters.CategoryNames.Any())
            {
                foreach (var categoryName in filteredParameters.CategoryNames)
                {
                    queryString += $"&categoryNames={Uri.EscapeDataString(categoryName)}";
                }
            }
            return queryString;
        }

        private class ProductListResponse
        {
            public int TotalCount { get; set; }
            public int TotalPages { get; set; }
            public List<ResultProductVM> Product { get; set; }
        }

    }
}
