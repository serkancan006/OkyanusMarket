using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Models.GroupVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Admin.Group
{
    public class ChangeGroupImagePartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public ChangeGroupImagePartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(string categoryName)
        {
            var value = new ChangeCategoryImageRequest()
            {
                CategoryName = categoryName,
            };
            return View(value);
        }
    }
}
