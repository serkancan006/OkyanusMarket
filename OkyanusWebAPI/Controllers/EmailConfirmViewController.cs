using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.Identitiy;

namespace OkyanusWebAPI.Controllers
{
    public class EmailConfirmViewController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmailConfirmViewController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Error");
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            
            return RedirectToAction("Error");
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
