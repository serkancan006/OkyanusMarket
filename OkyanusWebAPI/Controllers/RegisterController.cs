using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.Identitiy;
using System.Text;
using System.Web;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IConfiguration _configuration;

        public RegisterController(UserManager<AppUser> userManager, IMailService mailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _mailService = mailService;
            _configuration = configuration;
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
                token = HttpUtility.UrlEncode(Convert.ToBase64String(Encoding.UTF8.GetBytes(token)));
                //"https://localhost:7080/EmailConfirmView?userEmail=satakig519@hidelux.com&token=token"
                string callbackurl = _configuration["WebSiteHosts:Https"] + $"/Login/EMailConfirm?userEmail={user.Email}&token={token}";
                await _mailService.SendMailConfirmAsync(user.UserName, user.Email, callbackurl);
                return Ok("Kullanıcı başarıyla eklendi.Lütfen Mailinizi Aktif Ediniz.");
            }
            else
                return BadRequest(result.Errors);

        }
    }
}
