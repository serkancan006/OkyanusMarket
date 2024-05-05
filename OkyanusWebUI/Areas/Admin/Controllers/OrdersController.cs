using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Areas.Admin.Models.AdminOrderVM;
using OkyanusWebUI.Models.OrderDetailVM;
using OkyanusWebUI.Service;


namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        private readonly INotyfService _notyfService;
        public OrdersController(CustomHttpClient customHttpClient, INotyfService notyfService)
        {
            _customHttpClient = customHttpClient;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> Index([FromQuery] FilteredOrderParamaters filteredParameters)
        {
            var queryString = BuildQueryString(filteredParameters);


            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", QueryString = queryString });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<OrderListResponse>(jsonData);
                ViewBag.TotalPages = values?.TotalPages;
                ViewBag.PageNumber = filteredParameters.pageNumber;
                ViewBag.PageSize = filteredParameters.pageSize;
                ViewBag.OrderStatus = filteredParameters.OrderStatus;
                return View(values);
            }
            return View();
        }

        public IActionResult InstantOrder()
        {
            return View();
        }

        public async Task<IActionResult> DetailOrder(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAdminOrderVM>(jsonData);
                return View(values);
            }
            return View();
        }

        //public async Task<IActionResult> OrderItems(int id)
        //{
        //    var responseMessage = await _customHttpClient.Get(new() { Controller = "OrderDetail", Action= "OrderDetailList" }, id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<List<ResultOrderDetailVM>>(jsonData);
        //        return View(values);
        //    }
        //    return View();
        //}

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var responseMessage = await _customHttpClient.Delete(new() { Controller = "Order" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> OrderStatusOnay(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action="OrderStatusOnay" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Information("Sipariş Onaylandı");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrderStatusIptal(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "OrderStatusIptal" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Error("Sipariş İptal Edildi");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> OrderStatusHazirlama(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "OrderStatusHazirlama" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Information("Siparişi Hazırlayınız");
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> OrderStatusYolda(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "OrderStatusYolda" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Information("Siparişi Kuryeye Teslim Edin");
            }
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> OrderStatusTeslim(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "OrderStatusTeslim" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notyfService.Information("Sipariş Teslim Edildi. Stok Bilgileri Güncellendi.");
            }
            return RedirectToAction("Index");
        }

        private string BuildQueryString(FilteredOrderParamaters filteredParameters)
        {
            var queryString = "";

            if (filteredParameters?.pageNumber != null && filteredParameters?.pageSize != null)
            {
                queryString += $"pageNumber={filteredParameters.pageNumber}&pageSize={filteredParameters.pageSize}";
            }
            if (!string.IsNullOrEmpty(filteredParameters?.OrderStatus))
            {
                queryString += $"&orderStatus={filteredParameters.OrderStatus}";
            }

            return queryString;
        }


    }


    public class FilteredOrderParamaters
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public string? OrderStatus { get; set; }
    }

    public class OrderListResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<ResultAdminOrderVM> Orders { get; set; }
    }

}
