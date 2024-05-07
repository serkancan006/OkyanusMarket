using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebAPI.Models.CategorizeProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _CategorizeProductPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _CategorizeProductPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product", Action = "HomeCategorizeProductList" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<CategorizeProductVM>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
