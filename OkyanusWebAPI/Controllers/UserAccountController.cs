using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.UserAccountVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserAccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public UserAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAccount()
        {
            var username = HttpContext?.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            //var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            //var surnameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            if (user != null)
            {
                var result = new ResultUserAccountVM()
                {
                    UserEmail = user.Email,
                    UserFirstName = user.Name,
                    UserSurname = user.Surname,
                    //UserPhoneNumber = user.PhoneNumber
                };
                return Ok(result);
            }
            else
            {
                return NotFound("Kullanıcı BUlunamadı");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAccount(UpdateUserAccountVM model)
        {
            var username = HttpContext?.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            if (user != null)
            {
                user.Surname = model.UserSurname;
                user.Name = model.UserFirstName;
                //user.PhoneNumber = model.UserPhoneNumber;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok("Kullanıcı Bİlgileriniz güncellendi");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Kullanıcı güncellenirken bir hata oluştu.");
                }
            }
            else
            {
                return NotFound("Kullanıcı BUlunamadı");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            var username = HttpContext?.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }

            // Mevcut şifreyi kontrol et
            var passwordCheckResult = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (!passwordCheckResult)
            {
                return BadRequest("Mevcut şifre yanlış.");
            }

            // Yeni şifreyi ayarla
            var passwordChangeResult = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (passwordChangeResult.Succeeded)
            {
                return Ok("Şifre başarıyla güncellendi.");
            }
            else
            {
                // Şifre güncelleme işleminde hata oluştu
                var errors = passwordChangeResult.Errors.Select(e => e.Description).ToList();
                return BadRequest("Şifre güncellenirken bir hata oluştu: " + string.Join(", ", errors));
            }
        }

    }
}
