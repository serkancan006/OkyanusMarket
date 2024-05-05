using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductTypeVM;

namespace OkyanusWebUI.Service
{
    public class ProductTypeService
    {
        private readonly CustomHttpClient _customHttpClient;
        public ProductTypeService(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<List<SelectListItem>> GetProductTypeSelectListItems()
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "ProductType" });
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductTypeVM>>(jsonData);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var value in values)
            {
                SelectListItem item = new SelectListItem
                {
                    Value = value.ID.ToString(),
                    Text = value.Birim
                };
                selectListItems.Add(item);
            }
            return selectListItems;
        }
    }
}
