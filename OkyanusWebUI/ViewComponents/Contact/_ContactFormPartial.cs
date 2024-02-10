using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Models.ContactMessageVM;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.Contact
{
    public class _ContactFormPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ContactFormPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public IViewComponentResult Invoke()
        {
            var model = new CreateContactMessageVM();
            return View(model);
        }


    }
}
