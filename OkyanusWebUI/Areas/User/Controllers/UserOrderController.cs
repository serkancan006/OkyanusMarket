using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Areas.Admin.Models.AdminOrderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class UserOrderController : Controller
    {
        private readonly CustomHttpClient _customHttpClient;
        public UserOrderController(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "ListUserOrder" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAdminOrderVM>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> UserOrderDetail(int id)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Order", Action = "GetUserOrder" }, id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultAdminOrderVM>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
