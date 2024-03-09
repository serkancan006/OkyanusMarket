using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.Identitiy;
using System.Text;
using System.Web;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICreateTokenService _createTokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;
        public LoginController(SignInManager<AppUser> signInManager, ICreateTokenService createTokenService, UserManager<AppUser> userManager, IMailService mailService, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _createTokenService = createTokenService;
            _userManager = userManager;
            _mailService = mailService;
            _configuration = configuration;
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

        [HttpPost("[action]")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([FromBody] string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            //BU Kullanıcı yoksa veya mail adresini onaylamamış ise
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return Ok();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //Console.WriteLine(token);
            token = HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(token)));
            //"https://localhost:7080/EmailConfirmView?userEmail=satakig519@hidelux.com&token=token"
            string callbackurl = _configuration["WebSiteHosts:Https"] + $"/Login/ResetPassword?userEmail={user.Email}&token={token}";
            _mailService.SendMailForgotPassword(user.UserName, Email,"Şifre Sıfırlama", callbackurl);
            return Ok();
        }

        [HttpPost("[action]")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            //BU Kullanıcı yoksa
            if (user == null)
            {
                return Ok();
            }
            var result = await _userManager.ResetPasswordAsync(user, model.ResetToken, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> EMailConfirm(EMailConfirmVM model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            //Bu Kullanıcı Yoksa
            if (user == null)
            {
                return Ok();
            }
            var result = await _userManager.ConfirmEmailAsync(user, model.ConfirmToken);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

    }

    public class ResetPasswordVM
    {
        public string Email { get; set; }
        public string ResetToken { get; set; }
        public string NewPassword { get; set; }
    }

    public class EMailConfirmVM
    {
        public string Email { get; set; }
        public string ConfirmToken { get; set; }
    }
}
