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
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;

        public RegisterController(UserManager<AppUser> userManager, IMailService mailService)
        {
            _userManager = userManager;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserVM registerUserVM)
        {
            AppUser user = new AppUser()
            {
                Email = registerUserVM.Mail,
                UserName = registerUserVM.UserName,
                Name = registerUserVM.Name,
                Surname = registerUserVM.Surname,
                PhoneNumber = registerUserVM.PhoneNumber,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Status = true
            };

            var result = await _userManager.CreateAsync(user, registerUserVM.Password);
            if (result.Succeeded)
            {
                // Kullanıcı oluşturuldu, şimdi doğrulama e-postası gönder
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("Index", "EmailConfirmView", new
                {
                    userId = user.Id,
                    token = token
                }, protocol: HttpContext.Request.Scheme);
                _mailService.SendMailConfirm(user.UserName, user.Email, "Hesabını onayla", callbackUrl);
                return Ok("Kullanıcı başarıyla eklendi.Lütfen Mailinizi Aktif Ediniz.");
            }
            else
                return BadRequest(result.Errors);

        }
    }
}
