﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OkyanusWebUI.Models.ProductVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Admin.Product
{
    public class ChangeProductImagePartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public ChangeProductImagePartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(int productID)
        {
            var value = new ChangeProductImageRequest()
            {
                ProductID = productID
            };
            return View(value);
        }
    }
}
