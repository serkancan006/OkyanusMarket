using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.CategoryVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Product
{
    public class _ProductSidebarPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ProductSidebarPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? categoryID = null)
        {
            if (categoryID == null)
            {
                var responseMessage = await _customHttpClient.Get(new() { Controller = "Group", Action = "AnaGroupList" });
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(jsonData);
                    var result = new ResultGrupVM()
                    {
                        anagroup = values != null ? values.ToArray() : new ResultCategoryVM[] {},
                        altgruP1 = null,
                        altgruP2 = null,
                        alTGRUP3 = null
                    };
                    return View(result);
                }
            }
            else
            {
                var responseMessage = await _customHttpClient.Get(new() { Controller = "Group", Action = "MultiGroupList" },categoryID);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<ResultGrupVM>(jsonData);
                    return View(values);
                }
            }
        
            return View();
        }
    }
}
