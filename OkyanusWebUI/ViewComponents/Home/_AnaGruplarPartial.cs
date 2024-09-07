using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _AnaGruplarPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _AnaGruplarPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Group", Action = "GetAnaGroups" });
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAnaGroupList>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
    public class ResultAnaGroupList
    {
        public string GRUPADI { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
