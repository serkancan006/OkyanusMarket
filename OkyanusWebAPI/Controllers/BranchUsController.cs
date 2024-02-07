using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.BranchUsVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchUsController : ControllerBase
    {
        private readonly IBranchUsService _BranchUsService;
        private readonly IMapper _mapper;

        public BranchUsController(IBranchUsService BranchUsService, IMapper mapper)
        {
            _BranchUsService = BranchUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BranchUsList()
        {
            var values = _BranchUsService.TGetListAll();
            var result = _mapper.Map<List<ResultBranchUsVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBranchUs(CreateBranchUsVM BranchUsVM)
        {
            var value = _mapper.Map<BranchUs>(BranchUsVM);
            _BranchUsService.TAdd(value);
            return Ok("BranchUs Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBranchUs(int id)
        {
            var values = _BranchUsService.TGetByID(id);
            _BranchUsService.TDelete(values);
            return Ok("BranchUs Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBranchUs(UpdateBranchUsVM BranchUsVM)
        {
            var value = _mapper.Map<BranchUs>(BranchUsVM);
            _BranchUsService.TUpdate(value);
            return Ok("BranchUs Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBranchUs(int id)
        {
            var values = _BranchUsService.TGetByID(id);
            var result = _mapper.Map<ResultBranchUsVM>(values);
            return Ok(result);
        }
    }
}
