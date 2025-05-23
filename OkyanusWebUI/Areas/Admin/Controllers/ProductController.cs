﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly FileOperationService _fileOperationService;
        private readonly INotyfService _notyfService;
        private readonly ProductTypeService _productTypeService;
        private readonly MarkaService _markaService;
        public ProductController(CustomHttpClient customHttpClient, FileOperationService fileOperationService, INotyfService notyfService, ProductTypeService productTypeService, MarkaService markaService)
        {
            _customHttpClient = customHttpClient;
            _fileOperationService = fileOperationService;
            _notyfService = notyfService;
            _productTypeService = productTypeService;
            _markaService = markaService;
        }

        public async Task<IActionResult> Index([FromQuery] FilteredParameters filteredParameters)
        {
            var queryString = BuildQueryString(filteredParameters);

            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product", Action = "ProductListAll", QueryString = queryString });
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
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.ProductTypeSelectListItems = await _productTypeService.GetProductTypeSelectListItems();
            ViewBag.MarkaSelectListItems = await _markaService.GetMarkaSelectListItems();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductVM model)
        {
            ViewBag.ProductTypeSelectListItems = await _productTypeService.GetProductTypeSelectListItems();
            ViewBag.MarkaSelectListItems = await _markaService.GetMarkaSelectListItems();
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

        public async Task<IActionResult> DeleteProduct(string id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "Product" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.ProductTypeSelectListItems = await _productTypeService.GetProductTypeSelectListItems();
            ViewBag.MarkaSelectListItems = await _markaService.GetMarkaSelectListItems();
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
            ViewBag.ProductTypeSelectListItems = await _productTypeService.GetProductTypeSelectListItems();
            ViewBag.MarkaSelectListItems = await _markaService.GetMarkaSelectListItems();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var responseMessage = await _customHttpClient.Put<UpdateProductVM>(new() { Controller = "Product" }, model);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult AssignCategoryForProductList(string id)
        {
            return ViewComponent("AssignCategoryPartial", new { productID = id });
        }

        [HttpPost]
        public async Task<IActionResult> AssignCategoryForProduct(AssignCategoryForProductListResponse request)
        {
            AssignCategoryRequest assignCategoryRequestApi = new AssignCategoryRequest()
            {
                ProductID = request.ProductID,
                //CategoryID = request.ProductCategories.Where(x => x.IsSelected == true).Select(x => x.CategoryID).FirstOrDefault(),
                GRUPADI = request.SecilenCategoryAdı
            };
            var responseMessage = await _customHttpClient.Post<AssignCategoryRequest>(new() { Controller = "Product", Action = "AssignCategoryForProduct" }, assignCategoryRequestApi);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult changeImageProduct(string id)
        {
            return ViewComponent("ChangeProductImagePartial", new { productID = id });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImageProduct(ChangeProductImageRequest request)
        {
            if (request.FormFile == null)
            {
                var changeImageRequestApi = new ChangeProductImageApiRequest
                {
                    ProductID = request.ProductID,
                    ImagePath = null
                };

                var responseMessage = await _customHttpClient.Post<ChangeProductImageApiRequest>(
                    new() { Controller = "Product", Action = "ChangeProductImage" },
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
                var (fileName, databasePath) = await _fileOperationService.SaveFileAsync(request.FormFile, "images/product/");

                var changeImageRequestApi = new ChangeProductImageApiRequest
                {
                    ProductID = request.ProductID,
                    ImagePath = databasePath
                };

                var responseMessage = await _customHttpClient.Post<ChangeProductImageApiRequest>(
                    new() { Controller = "Product", Action = "ChangeProductImage" },
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


        private class ChangeProductImageApiRequest
        {
            public string? ImagePath { get; set; }
            public string ProductID { get; set; }
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
