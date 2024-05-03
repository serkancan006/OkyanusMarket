using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models.UserAdresVM;

namespace OkyanusWebAPI.Controllers
{
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UserAdresList()
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = _UserAdresService.TGetListAll().Where(x => x.AppUserID == user.Id);
            var result = _mapper.Map<List<ResultUserAdresVM>>(values);
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUserAdres(CreateUserAdresVM UserAdresVM)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            //var value = _mapper.Map<UserAdres>(UserAdresVM);
            //value.UserIlce = _districtService.TGetByID(int.Parse(UserAdresVM.UserIlce)).DistrictName;
            //value.UserSehir = _cityService.TGetByID(int.Parse(UserAdresVM.UserSehir)).CityName;
            //value.AppUserID = user.Id;
            //value.Selected = false;
            //_UserAdresService.TAdd(value);
            if (user != null)
            {
                _UserAdresService.TAdd(new UserAdres()
                {
                    AppUserID = user.Id,
                    UserApartman = UserAdresVM.UserApartman,
                    UserDaire = UserAdresVM.UserDaire,
                    UserKat = UserAdresVM.UserKat,
                    UserAdress = UserAdresVM.UserAdress,
                    UserIlce = _districtService.TGetByID(int.Parse(UserAdresVM.UserIlce)).DistrictName,
                    UserSehir = _cityService.TGetByID(int.Parse(UserAdresVM.UserSehir)).CityName
                });
                return Ok("UserAdres Eklendi");
            }
            else
            {
                return NotFound("Kullanıcı Bulunamadı");
            }
     
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAdres(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = _UserAdresService.TGetByID(id);
            if (values.AppUserID == user.Id)
            {
                _UserAdresService.TDelete(values);
                return Ok("UserAdres Silindi");
            }
            return NotFound();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAdres(UpdateUserAdresVM UserAdresVM)
        {
            var existingUserAdres = _UserAdresService.TGetByID(UserAdresVM.ID);
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
           
            //var value = _mapper.Map<UserAdres>(UserAdresVM);
            if (existingUserAdres.AppUserID == user.Id)
            {
                existingUserAdres.UserAdress = UserAdresVM.UserAdress;
                existingUserAdres.UserDaire = UserAdresVM.UserDaire;
                existingUserAdres.UserApartman = UserAdresVM.UserApartman;
                existingUserAdres.UserKat = UserAdresVM.UserKat;
                existingUserAdres.UserIlce = _districtService.TGetByID(int.Parse(UserAdresVM.UserIlce)).DistrictName;
                existingUserAdres.UserSehir = _cityService.TGetByID(int.Parse(UserAdresVM.UserSehir)).CityName;
                existingUserAdres.AppUserID = user.Id;
                _UserAdresService.TUpdate(existingUserAdres);
                return Ok("UserAdres Güncellendi");
            }
            return NotFound();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAdres(int id)
        {
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            var values = _UserAdresService.TGetByID(id);
            if (values.AppUserID == user.Id)
            {
                var result = _mapper.Map<ResultUserAdresVM>(values);
                return Ok(result);
            }
            return NotFound();
        }

       

    }
}
