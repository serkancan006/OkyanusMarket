using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get4AnaGroupRandomList()
        {
            var values = _GroupService.TGetListAll()
                .Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" 
                //&& x.Status == true
                )
                .OrderBy(x => new Random().Next())
                .Select(x => new { 
                    //x.ID,
                    x.GRUPADI, x.Description })
                .Take(4)
                .ToList();
            return Ok(values);
        }

        [HttpGet("[Action]")] //product sidebar
        public IActionResult MultiGroupList(string? categoryName)
        {
            var values = _GroupService.TGetListAll().Where(x => x.GRUPADI == categoryName 
            //&& x.Status == true
            ).FirstOrDefault();
            var allGroups = _GroupService.TGetListAll();
            var anagroup = allGroups.Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" 
            //&& x.Status == true
            ).Select(x => new { x.GRUPADI,
                //x.ID, 
                selected = x.ANAGRUP == values?.ANAGRUP }).ToList();
            var altgrup1 = allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" 
            //&& x.Status == true
            ).Select(x => new { x.GRUPADI,
                //x.ID, 
                selected = x.ALTGRUP1 == values?.ALTGRUP1 }).ToList();
            var altgrup2 = values?.ALTGRUP1 != "0" ? allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 == values?.ALTGRUP1 && x.ALTGRUP2 != "0" && x.ALTGRUP3 == "0" 
            //&& x.Status == true
            ).Select(x => new { x.GRUPADI,
                //x.ID, 
                selected = x.ALTGRUP2 == values?.ALTGRUP2 }).ToList() : null;
            var altgrup3 = values?.ALTGRUP2 != "0" ? allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 == values?.ALTGRUP1 && x.ALTGRUP2 == values?.ALTGRUP2 && x.ALTGRUP3 != "0" 
            //&& x.Status == true
            ).Select(x => new { x.GRUPADI,
                //x.ID,
                selected = x.ALTGRUP3 == values?.ALTGRUP3 }).ToList() : null;

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
        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public IActionResult GroupListCategorize()
        {
            var values = _GroupService.TGetListAll();
            var result = _mapper.Map<List<ResultGroupVM>>(values);
            return Ok(new
            {
                AnaGrup = result.Where(x => x.ANAGRUP != "0" && x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0"),
                AltGrup1 = result.Where(x => x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0"),
                AltGrup2 = result.Where(x => x.ALTGRUP2 != "0" && x.ALTGRUP3 == "0"),
                AltGrup3 = result.Where(x => x.ALTGRUP3 != "0"),
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GroupList()
        {
            var values = _GroupService.TGetListAll();
            var result = _mapper.Map<List<ResultGroupVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddGroup(CreateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            _GroupService.TAdd(value);
            return Ok("Group Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{grupAdı}")]
        public IActionResult DeleteGroup(string grupAdı)
        {
            var values = _GroupService.TAsQueryable().Where(x => x.GRUPADI == grupAdı).SingleOrDefault();
            _GroupService.TDelete(values);
            return Ok("Group Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateGroup(UpdateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            _GroupService.TUpdate(value);
            return Ok("Group Güncellendi");
        }

        [HttpGet("{grupAdı}")]
        public IActionResult GetGroup(string grupAdı)
        {
            var values = _GroupService.TAsQueryable().Where(x => x.GRUPADI == grupAdı).SingleOrDefault();
            var result = _mapper.Map<ResultGroupVM>(values);
            return Ok(result);
        }
    }
}
