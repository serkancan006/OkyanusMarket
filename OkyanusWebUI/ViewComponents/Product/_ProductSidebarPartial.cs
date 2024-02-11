using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.CategoryVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Product
{
    public class _ProductSidebarPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ProductSidebarPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Category" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
