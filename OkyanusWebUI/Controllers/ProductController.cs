using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;

        public ProductController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
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
                return View(values?.Product);
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
