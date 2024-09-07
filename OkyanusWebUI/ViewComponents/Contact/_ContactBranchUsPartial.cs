using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.BranchUsVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Contact
{
    public class _ContactBranchUsPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ContactBranchUsPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "BranchUs" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBranchUsVM>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
