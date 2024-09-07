using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.SliderVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _SliderPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _SliderPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Slider" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderVM>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
