using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.Identitiy;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICreateTokenService _createTokenService;
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, ICreateTokenService createTokenService, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _createTokenService = createTokenService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginUserVM loginUserVM)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginUserVM.UsernameOrEmail) ?? await _userManager.FindByEmailAsync(loginUserVM.UsernameOrEmail);

                if (user != null)
                {
                    // Kullanıcı e-posta adresini onaylamamışsa
                    if (!user.EmailConfirmed)
                    {
                        return BadRequest(new { message = "Lütfen e-posta adresinizi onaylayınız.", status = false });
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, loginUserVM.Password, false, true);
                    if (result.Succeeded)
                    {
                        if (user != null)
                        {
                            var userRoles = await _userManager.GetRolesAsync(user);
                            if (userRoles.Contains("Admin"))
                            {
                                // Kullanıcı Admin içeriği rolü içeriyorsa 
                                var value = _createTokenService.TokenCreateAdmin(user);
                                return Ok(new { message = "Admini girişi başarılı.", value });
                            }
                            else
                            {
                                var value = _createTokenService.TokenCreate(user);
                                return Ok(new { message = "Kullanıcı girişi başarılı.", value });
                            }
                        }
                        //return Ok(value);
                    }
                    else
                        return BadRequest(new { message = "Kullanıcı adı veya şifre hatalı.", status = false, error = result });
                }
                return BadRequest(new { message = "Bu kullanıcı bulunamadı", status = false });
            }
            return BadRequest(new { message = "Gönderilen veriler hatalı.", status = false });
        }

    }
}
