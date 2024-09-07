using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.FavoriUrunlerVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FavoriUrunlerController : ControllerBase
    {
        private readonly IFavoriUrunlerService _FavoriUrunlerService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public FavoriUrunlerController(IFavoriUrunlerService FavoriUrunlerService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _FavoriUrunlerService = FavoriUrunlerService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> FavoriUrunlerList()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var result = await _FavoriUrunlerService.TGetFavoriUrunlersByUserAsync(user.Id);
                var values = _mapper.Map<List<ResultFavoriUrunlerVM>>(result);
                return Ok(values);
            }
            else
                return NotFound("Kullanıcı Bulunamadı");
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriUrunler(CreateFavoriUrunlerVM FavoriUrunlerVM)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var hasfavoriUrunbyuser = await _FavoriUrunlerService.TAsQueryable().AnyAsync(x => x.ProductID == FavoriUrunlerVM.ProductID && x.AppUserID == user.Id);
                if (hasfavoriUrunbyuser)
                {
                    return Ok("Favori Ürün Eklendi");
                }
                await _FavoriUrunlerService.TAddAsync(new()
                {
                    AppUserID = user.Id,
                    ProductID = FavoriUrunlerVM.ProductID
                });
                return Ok("Favori Ürün Eklendi");
            }
            else
                return NotFound("Kullanıcı Bulunamadı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavoriUrunler(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var values = await _FavoriUrunlerService.TGetByIDAsync(id);
                await _FavoriUrunlerService.TDeleteAsync(values);
                return Ok("Favori Ürün Eklendi");
            }
            else
                return NotFound("Kullanıcı Bulunamadı");
        }

    }
}
