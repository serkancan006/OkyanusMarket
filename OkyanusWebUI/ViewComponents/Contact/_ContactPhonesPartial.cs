using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.MyPhoneVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Contact
{
    public class _ContactPhonesPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ContactPhonesPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "MyPhone" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMyPhoneVM>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
