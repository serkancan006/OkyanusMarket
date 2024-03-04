using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.EntityLayer.Entities.identitiy;
using System.Security.Claims;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserInfoForOrder()
        {
            var username = HttpContext?.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(username);
            //var nameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            //var surnameClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
            return Ok(new { FirstName = user.Name, SurName = user.Surname, Email = user.Email, Phone = user.PhoneNumber });
        }
    }
}
