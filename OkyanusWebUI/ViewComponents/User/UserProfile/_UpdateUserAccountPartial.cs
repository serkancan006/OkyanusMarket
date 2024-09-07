using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAccountVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.User.UserProfile
{
    public class _UpdateUserAccountPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _UpdateUserAccountPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "UserAccount" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultUserAccountVM>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
