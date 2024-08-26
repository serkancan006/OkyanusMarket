using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents
{
    public class _ProductDetailModalPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ProductDetailModalPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(string productID)
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
