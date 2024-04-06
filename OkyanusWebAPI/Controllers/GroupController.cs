using AutoMapper;
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

        [HttpGet]
        public IActionResult GroupList()
        {
            var values = _GroupService.TGetListAll();
            var result = _mapper.Map<List<ResultGroupVM>>(values);
            return Ok(result);
        }

        [HttpGet("[Action]")]
        public IActionResult AnaGroupList()
        {
            var values = _GroupService.TGetListAll().Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" && x.Status == true).Select(x => new { x.ID, x.GRUPADI }).ToList();
            return Ok(values);
        }

        [HttpGet("[Action]")]
        public IActionResult Get4AnaGroupRandomList()
        {
            var values = _GroupService.TGetListAll()
                .Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" && x.Status == true )
                .OrderBy(x => new Random().Next())
                .Select(x => new { x.ID, x.GRUPADI })
                .Take(4)
                .ToList();
            return Ok(values);
        }

        [HttpGet("[Action]/{groupID}")]
        public IActionResult MultiGroupList(int groupID)
        {
            var values = _GroupService.TGetListAll().Where(x => x.ID == groupID).FirstOrDefault();
            var allGroups = _GroupService.TGetListAll();

            var result = new
            {
                ANAGROUP = allGroups.Where(x => x.ALTGRUP1 == "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" && x.Status == true).Select(x => new { x.GRUPADI, x.ID, selected = x.ANAGRUP == values?.ANAGRUP }).ToList(),

                ALTGRUP1 = (allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 != "0" && x.ALTGRUP2 == "0" && x.ALTGRUP3 == "0" && x.Status == true).Select(x => new { x.GRUPADI, x.ID, selected = x.ALTGRUP1 == values?.ALTGRUP1 }).ToList()),

                ALTGRUP2 = values?.ALTGRUP1 != "0" ? (allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 == values?.ALTGRUP1 && x.ALTGRUP2 != "0" && x.ALTGRUP3 == "0" && x.Status == true).Select(x => new { x.GRUPADI, x.ID, selected = x.ALTGRUP2 == values?.ALTGRUP2 }).ToList()) : null,

                AlTGRUP3 = values?.ALTGRUP2 != "0" ? (allGroups.Where(x => x.ANAGRUP == values?.ANAGRUP && x.ALTGRUP1 == values?.ALTGRUP1 && x.ALTGRUP2 == values?.ALTGRUP2 && x.ALTGRUP3 != "0" && x.Status == true).Select(x => new { x.GRUPADI, x.ID, selected = x.ALTGRUP3 == values?.ALTGRUP3 }).ToList()) : null
            };

            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddGroup(CreateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            _GroupService.TAdd(value);
            return Ok("Group Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            var values = _GroupService.TGetByID(id);
            _GroupService.TDelete(values);
            return Ok("Group Silindi");
        }

        [HttpPut]
        public IActionResult UpdateGroup(UpdateGroupVM GroupVM)
        {
            var value = _mapper.Map<Group>(GroupVM);
            _GroupService.TUpdate(value);
            return Ok("Group Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetGroup(int id)
        {
            var values = _GroupService.TGetByID(id);
            var result = _mapper.Map<ResultGroupVM>(values);
            return Ok(result);
        }
    }
}
