using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.MarkaVM;

namespace OkyanusWebUI.Service
{
    public class MarkaService
    {
        private readonly CustomHttpClient _customHttpClient;
        public MarkaService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetMarkaSelectListItems()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Marka" });
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMarkaVM>>(jsonData);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var value in values)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.MarkaAdı
                };
                selectListItems.Add(item);
            }
            return selectListItems;
        }
    }
}
