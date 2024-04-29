using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.UserAdresVM;

namespace OkyanusWebUI.Service
{
    public class UserAdresService
    {
        private readonly CustomHttpClient _customHttpClient;
        public UserAdresService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetUserAdres()
        {
            var responseMessage2 = await _customHttpClient.Get(new() { Controller = "UserAdres" });
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<List<ResultUserAdresVM>>(jsonData2);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem() { Value = "0", Text = "Adres Ekle" });
            foreach (var value in values2)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.UserAdress
                };
                selectListItems.Add(item);
            }
            return selectListItems;
        }
    }
}
