using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.TermsAndConditionVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TermsAndConditionController : ControllerBase
    {
        private readonly ITermsAndConditionService _TermsAndConditionService;
        private readonly IMapper _mapper;

        public TermsAndConditionController(ITermsAndConditionService TermsAndConditionService, IMapper mapper)
        {
            _TermsAndConditionService = TermsAndConditionService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TermsAndConditionList()
        {
            var values = await _TermsAndConditionService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultTermsAndConditionVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddTermsAndCondition(CreateTermsAndConditionVM TermsAndConditionVM)
        {
            var value = _mapper.Map<TermsAndCondition>(TermsAndConditionVM);
            await _TermsAndConditionService.TAddAsync(value);
            return Ok("TermsAndCondition Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTermsAndCondition(int id)
        {
            var values = await _TermsAndConditionService.TGetByIDAsync(id);
            await _TermsAndConditionService.TDeleteAsync(values);
            return Ok("TermsAndCondition Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateTermsAndCondition(UpdateTermsAndConditionVM TermsAndConditionVM)
        {
            var value = _mapper.Map<TermsAndCondition>(TermsAndConditionVM);
            await _TermsAndConditionService.TUpdateAsync(value);
            return Ok("TermsAndCondition Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTermsAndCondition(int id)
        {
            var values = await _TermsAndConditionService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultTermsAndConditionVM>(values);
            return Ok(result);
        }
    }
}
