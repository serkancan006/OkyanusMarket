﻿using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.ViewComponents.Home
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
