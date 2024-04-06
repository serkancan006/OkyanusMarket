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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProducts([FromQuery] FilteredParameters filteredParameters)
        {
            var queryString = BuildQueryString(filteredParameters);

            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product", QueryString = queryString });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ProductListResponse>(jsonData);
                return Json(values);
            }
            return StatusCode(500, "Bir hata oluştu Product - GetProducts");
        }

        public class FilteredParameters
        {
            public string? SearchName { get; set; }
            public string? MarkaAdi { get; set; }
            public string? CategoryName { get; set; }
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
            if (!string.IsNullOrEmpty(filteredParameters.MarkaAdi))
            {
                queryString += $"&markaAdi={filteredParameters.MarkaAdi}";
            }

            if (filteredParameters.CategoryName != null && filteredParameters.CategoryName.Any())
            {
                queryString += $"&categoryName={filteredParameters.CategoryName}";
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
