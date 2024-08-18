using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.MvcModels;

namespace OkyanusWebAPI.ControllersMvc
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICreateTokenService _createTokenService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ICreateTokenService createTokenService, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _createTokenService = createTokenService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult HangfireLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> HangfireLogin(HangfireLoginVM model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
                if (result.Succeeded) 
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (userRoles.Contains("Admin"))
                    {
                        // Kullanıcı Admin içeriği rolü içeriyorsa 
                        var value = _createTokenService.TokenCreateAdmin(user, 60 * 60 * 24);
                        SetToken(value.Token, value.Expires.ToString());
                        return View("hangfire");
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            return View();
        }

        private const string TokenKey = "Token";
        private const string TokenExpiresKey = "TokenExpires";

        private void SetToken(string token, string expires)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString(TokenKey, token);
            _httpContextAccessor?.HttpContext?.Session.SetString(TokenExpiresKey, expires);
        }

        public string? GetToken()
        {
            return _httpContextAccessor?.HttpContext?.Session.GetString(TokenKey);
        }
    }
}
