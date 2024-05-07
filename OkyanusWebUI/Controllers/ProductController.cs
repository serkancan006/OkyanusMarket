using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                ViewBag.PageNumber = filteredParameters.PageNumber;
                ViewBag.SearchName = filteredParameters.SearchName;
                ViewBag.CategoryName = filteredParameters.CategoryName;
                ViewBag.sortField = filteredParameters.sortField;
                ViewBag.MarkaAdi = filteredParameters.MarkaAdi;
                return View(values);
            }
            return View();
        }


        public IActionResult _OrderDetailModal(int id)
        {
            return ViewComponent("_ProductDetailModalPartial", new { productID = id });
        }


        public class FilteredParameters
        {
            public string? SearchName { get; set; }
            public string? MarkaAdi { get; set; }
            public string? CategoryName { get; set; }
            public int? PageNumber { get; set; } = 1;
            public int? PageSize { get; set; } = 40;
            public string? sortField { get; set; } // Sıralama alanı
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

            if (!string.IsNullOrEmpty(filteredParameters.sortField))
            {
                switch (filteredParameters.sortField.ToLower())
                {
                    case "productname":
                        queryString += $"&sortField=productname";
                        break;
                    case "productnameasc":
                        queryString += $"&sortField=productname";
                        queryString += $"&sortOrder=asc";
                        break;
                    case "price":
                        queryString += $"&sortField=price";
                        break;
                    case "priceasc":
                        queryString += $"&sortField=price";
                        queryString += $"&sortOrder=asc";
                        break;
                    //case "indirimli":
                    //    queryString += $"&sortField=indirim";
                    //    break;
                    //case "indirimsiz":
                    //    queryString += $"&sortField=indirim";
                    //    queryString += $"&sortOrder=asc";
                    //    break;
                    default:
                        break;
                }
            }

            

            return queryString;
        }

    }
    public class ProductListResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<ResultProductVM> Product { get; set; }
    }

}
