using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Areas.Admin.Models.AdminOrderVM;
using OkyanusWebUI.Models.OrderDetailVM;
using OkyanusWebUI.Service;


namespace OkyanusWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public OrdersController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminOrderVM>>(jsonData);
                return View(values);
            }
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

        public async Task<IActionResult> OrderItems(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "OrderDetail", Action= "OrderDetailList" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDetailVM>>(jsonData);
                return View(values);
            }
            return View();
        }


    }
}
