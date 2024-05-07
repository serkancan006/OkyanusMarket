using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.CityVM;
using OkyanusWebUI.Models.DeliveryTimeVM;
using OkyanusWebUI.Models.DistrictVM;

namespace OkyanusWebUI.Service
{
    public class CityService
    {
        private readonly CustomHttpClient _customHttpClient;
        public CityService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetCityList()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "City" });
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCityVM>>(jsonData);

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            if (values != null || values?.Count > 0)
            {
                foreach (var value in values)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Value = value.ID.ToString(),
                        Text = value.CityName,
                    };
                    selectListItems.Add(item);
                }
            }
            
            return selectListItems;
        }


        public async Task<List<SelectListItem>> GetDistrictListByCity(int cityId)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "District" }, cityId);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDistrictVM>>(jsonData);

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            if (values != null || values?.Count > 0)
            {
                foreach (var value in values)
                {
                    SelectListItem item = new SelectListItem
                    {
                        Value = value.ID.ToString(),
                        Text = value.DistrictName,
                    };
                    selectListItems.Add(item);
                }
            }
            return selectListItems;
        }


    }
}
