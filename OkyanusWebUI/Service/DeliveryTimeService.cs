using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.DeliveryTimeVM;

namespace OkyanusWebUI.Service
{
    public class DeliveryTimeService
    {
        private readonly CustomHttpClient _customHttpClient;
        public DeliveryTimeService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetDeliveryTimeList()
        {
            var responseMessage2 = await _customHttpClient.Get(new() { Controller = "DeliveryTime" });
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultDeliveryTimeVM>>(jsonData2);
           
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            if (values2 == null)
            {
                selectListItems.Add(new SelectListItem()
                {
                    Value = null,
                    Text = "online siparişlerimiz şimdilik kapılıdır!",
                    Disabled = true,
                });
            }
            else
            {
                foreach (var value in values2)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Value = value.ID.ToString(),
                        Text = $"{value.StartedTime:hh\\:mm} - {value.EndTime:hh\\:mm}",
                    };
                    selectListItems.Add(item);
                }
            }
            return selectListItems;
        }
    }
}
