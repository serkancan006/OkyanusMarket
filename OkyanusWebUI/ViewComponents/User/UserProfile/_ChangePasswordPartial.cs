using Microsoft.AspNetCore.Mvc;
using OkyanusWebUI.Service;

namespace OkyanusWebUI.ViewComponents.User.UserProfile
{
    public class _ChangePasswordPartial : ViewComponent
    {
        private readonly CustomHttpClient _customHttpClient;
        public _ChangePasswordPartial(CustomHttpClient customHttpClient)
        {
            _customHttpClient = customHttpClient;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
