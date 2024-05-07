using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> BranchUsList()
        {
            var values = await _BranchUsService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultBranchUsVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddBranchUs(CreateBranchUsVM BranchUsVM)
        {
            var value = _mapper.Map<BranchUs>(BranchUsVM);
            await _BranchUsService.TAddAsync(value);
            return Ok("BranchUs Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranchUs(int id)
        {
            var values = await _BranchUsService.TGetByIDAsync(id);
            await _BranchUsService.TDeleteAsync(values);
            return Ok("BranchUs Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateBranchUs(UpdateBranchUsVM BranchUsVM)
        {
            var value = _mapper.Map<BranchUs>(BranchUsVM);
            await _BranchUsService.TUpdateAsync(value);
            return Ok("BranchUs Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranchUs(int id)
        {
            var values = await _BranchUsService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultBranchUsVM>(values);
            return Ok(result);
        }
    }
}
