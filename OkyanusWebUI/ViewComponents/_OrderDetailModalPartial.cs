using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents
{
    public class _OrderDetailModalPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _OrderDetailModalPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product" }, productID);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductVM>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
