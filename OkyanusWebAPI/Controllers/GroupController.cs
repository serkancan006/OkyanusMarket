using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.GroupVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;
        private readonly IMapper _mapper;

        public GroupController(IGroupService GroupService, IMapper mapper)
        {
            _GroupService = GroupService;
            _mapper = mapper;
        }

        [HttpGet("[Action]")] //anasayfa da random 4 kategori listeleme için kullanılıyor
        public async Task<IActionResult> Get4AnaGroupRandomList()
        {
            var values = await _GroupService.TAsQueryable()
                .Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" 
                //&& x.Status == true
                )
                //.OrderBy(x => new Random().Next())
                .Select(x => new { 
                    //x.ID,
                    x.GRUPADI, x.Description })
                .Take(4)
                .ToListAsync();
            return Ok(values);
        }

        [HttpGet("[Action]")] //product sidebar
        public async Task<IActionResult> MultiGroupList(string? categoryName)
        {
            var values = await _GroupService.TAsQueryable().Where(x => x.GRUPADI == categoryName).FirstOrDefaultAsync();
            var allGroups = _GroupService.TAsQueryable();

            var anagroup = await allGroups
                .Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0")
                .Select(x => new { x.GRUPADI, selected = values != null && x.ANAGRUP == values.ANAGRUP })
                .ToListAsync();

            var altgrup1 = await allGroups
                .Where(x => values != null && x.ANAGRUP == values.ANAGRUP && x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0")
                .Select(x => new { x.GRUPADI, selected = values != null && x.ALTGRUP1 == values.ALTGRUP1 })
                .ToListAsync();

            var altgrup2 = values?.ALTGRUP1 != "0" ? await allGroups
                .Where(x => values != null && x.ANAGRUP == values.ANAGRUP && x.ALTGRUP1 == values.ALTGRUP1 && x.ALTGRUP2 != "0" && x.ALTGRUP3 == "0")
                .Select(x => new { x.GRUPADI, selected = values != null && x.ALTGRUP2 == values.ALTGRUP2 })
                .ToListAsync() : null;

            var altgrup3 = values?.ALTGRUP2 != "0" ? await allGroups
                .Where(x => values != null && x.ANAGRUP == values.ANAGRUP && x.ALTGRUP1 == values.ALTGRUP1 && x.ALTGRUP2 == values.ALTGRUP2 && x.ALTGRUP3 != "0")
                .Select(x => new { x.GRUPADI, selected = values != null && x.ALTGRUP3 == values.ALTGRUP3 })
                .ToListAsync() : null;

            var result = new
            {
                ANAGROUP = anagroup,
                ALTGRUP1 = altgrup1,
                ALTGRUP2 = altgrup2,
                ALTGRUP3 = altgrup3
            };

            return Ok(result);
        }

        //Admin
        //[Authorize(Roles = "Admin")]
        //[HttpGet("[action]")]
        //public IActionResult GroupListCategorize()
        //{
        //    var values = _GroupService.TGetListAll();
        //    var result = _mapper.Map<List<ResultGroupVM>>(values);
        //    return Ok(new
        //    {
        //        AnaGrup = result.Where(x => x.ANAGRUP != "0" && x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0"),
        //        AltGrup1 = result.Where(x => x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0"),
        //        AltGrup2 = result.Where(x => x.ALTGRUP2 != "0" && x.ALTGRUP3 == "0"),
        //        AltGrup3 = result.Where(x => x.ALTGRUP3 != "0"),
        //    });
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GroupList()
        {
            var values = await _GroupService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultGroupVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddGroup(CreateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            await _GroupService.TAddAsync(value);
            return Ok("Group Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{grupAdı}")]
        public async Task<IActionResult> DeleteGroup(string grupAdı)
        {
            var values = await _GroupService.TAsQueryable().Where(x => x.GRUPADI == grupAdı).SingleOrDefaultAsync();
            await _GroupService.TDeleteAsync(values);
            return Ok("Group Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateGroup(UpdateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            await _GroupService.TUpdateAsync(value);
            return Ok("Group Güncellendi");
        }

        [HttpGet("{grupAdı}")]
        public async Task<IActionResult> GetGroup(string grupAdı)
        {
            var values = await _GroupService.TAsQueryable().Where(x => x.GRUPADI == grupAdı).SingleOrDefaultAsync();
            var result = _mapper.Map<ResultGroupVM>(values);
            return Ok(result);
        }
    }
}
