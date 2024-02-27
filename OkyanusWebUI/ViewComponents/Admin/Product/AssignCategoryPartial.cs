using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.BranchUsVM;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Admin.Product
{
    public class AssignCategoryPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public AssignCategoryPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            var responseMessage = await _customHttpClient.Get(new() { Controller = "Product", Action= "AssignCategoryForProductList" }, productID);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<AssignCategoryForProductListResponse>(jsonData);
                values.ProductID = productID;
                return View(values);
            }
            return View();
        }
    }
}
