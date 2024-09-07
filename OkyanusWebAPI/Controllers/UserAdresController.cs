using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.UserAdresVM;

namespace OkyanusWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAdresController : ControllerBase
    {
        private readonly IUserAdresService _UserAdresService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;

        public UserAdresController(IUserAdresService UserAdresService, IMapper mapper, UserManager<AppUser> userManager, ICityService cityService, IDistrictService districtService)
        {
            _UserAdresService = UserAdresService;
            _mapper = mapper;
            _userManager = userManager;
            _cityService = cityService;
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<IActionResult> UserAdresList()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = await _UserAdresService.TAsQueryable().Where(x => x.AppUserID == user.Id).ToListAsync();
            var result = _mapper.Map<List<ResultUserAdresVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAdres(CreateUserAdresVM UserAdresVM)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            if (user != null)
            {
                var district = await _districtService.TGetByIDAsync(int.Parse(UserAdresVM.UserIlce));
                var city = await _cityService.TGetByIDAsync(int.Parse(UserAdresVM.UserSehir));

                if (district != null && city != null)
                {
                    await _UserAdresService.TAddAsync(new UserAdres()
                    {
                        AppUserID = user.Id,
                        UserApartman = UserAdresVM.UserApartman,
                        UserDaire = UserAdresVM.UserDaire,
                        UserKat = UserAdresVM.UserKat,
                        UserAdress = UserAdresVM.UserAdress,
                        UserIlce = district.DistrictName,
                        UserSehir = city.CityName
                    });

                    return Ok("UserAdres Eklendi");
                }
                else
                {
                    return NotFound("İlçe veya şehir bulunamadı");
                }
            }
            else
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAdres(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = await _UserAdresService.TGetByIDAsync(id);
            if (values.AppUserID == user.Id)
            {
                await _UserAdresService.TDeleteAsync(values);
                return Ok("UserAdres Silindi");
            }
            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAdres(UpdateUserAdresVM UserAdresVM)
        {
            var existingUserAdres = await _UserAdresService.TGetByIDAsync(UserAdresVM.ID);
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);

            if (existingUserAdres.AppUserID == user.Id)
            {
                var district = await _districtService.TGetByIDAsync(int.Parse(UserAdresVM.UserIlce));
                var city = await _cityService.TGetByIDAsync(int.Parse(UserAdresVM.UserSehir));

                if (district != null && city != null)
                {
                    existingUserAdres.UserAdress = UserAdresVM.UserAdress;
                    existingUserAdres.UserDaire = UserAdresVM.UserDaire;
                    existingUserAdres.UserApartman = UserAdresVM.UserApartman;
                    existingUserAdres.UserKat = UserAdresVM.UserKat;
                    existingUserAdres.UserIlce = district.DistrictName;
                    existingUserAdres.UserSehir = city.CityName;
                    existingUserAdres.AppUserID = user.Id;

                    await _UserAdresService.TUpdateAsync(existingUserAdres);
                    return Ok("UserAdres Güncellendi");
                }
                else
                {
                    return NotFound("İlçe veya şehir bulunamadı");
                }
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAdres(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = await _UserAdresService.TGetByIDAsync(id);
            if (values.AppUserID == user.Id)
            {
                var result = _mapper.Map<ResultUserAdresVM>(values);
                return Ok(result);
            }
            return NotFound();
        }

    }
}
