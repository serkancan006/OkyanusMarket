using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UserAdresController(IUserAdresService UserAdresService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _UserAdresService = UserAdresService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult UserAdresList()
        {
            var values = _UserAdresService.TGetListAll();
            var result = _mapper.Map<List<ResultUserAdresVM>>(values);
            return Ok(result);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddUserAdres(CreateUserAdresVM UserAdresVM)
        {
            var value = _mapper.Map<UserAdres>(UserAdresVM);
            var user = await _userManager.FindByNameAsync(User?.Identity?.Name);
            value.AppUserID = user.Id;
            value.Selected = false;
            _UserAdresService.TAdd(value);
            return Ok("UserAdres Eklendi");
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUserAdres(int id)
        {
            var values = _UserAdresService.TGetByID(id);
            _UserAdresService.TDelete(values);
            return Ok("UserAdres Silindi");
        }

        [Authorize]
        [HttpPut]
        public IActionResult UpdateUserAdres(UpdateUserAdresVM UserAdresVM)
        {
            var value = _mapper.Map<UserAdres>(UserAdresVM);
            _UserAdresService.TUpdate(value);
            return Ok("UserAdres Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserAdres(int id)
        {
            var values = _UserAdresService.TGetByID(id);
            var result = _mapper.Map<ResultUserAdresVM>(values);
            return Ok(result);
        }
    }
}
