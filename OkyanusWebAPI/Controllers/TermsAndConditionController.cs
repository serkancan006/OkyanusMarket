using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        public IActionResult TermsAndConditionList()
        {
            var values = _TermsAndConditionService.TGetListAll();
            var result = _mapper.Map<List<ResultTermsAndConditionVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddTermsAndCondition(CreateTermsAndConditionVM TermsAndConditionVM)
        {
            var value = _mapper.Map<TermsAndCondition>(TermsAndConditionVM);
            _TermsAndConditionService.TAdd(value);
            return Ok("TermsAndCondition Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTermsAndCondition(int id)
        {
            var values = _TermsAndConditionService.TGetByID(id);
            _TermsAndConditionService.TDelete(values);
            return Ok("TermsAndCondition Silindi");
        }

        [HttpPut]
        public IActionResult UpdateTermsAndCondition(UpdateTermsAndConditionVM TermsAndConditionVM)
        {
            var value = _mapper.Map<TermsAndCondition>(TermsAndConditionVM);
            _TermsAndConditionService.TUpdate(value);
            return Ok("TermsAndCondition Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTermsAndCondition(int id)
        {
            var values = _TermsAndConditionService.TGetByID(id);
            var result = _mapper.Map<ResultTermsAndConditionVM>(values);
            return Ok(result);
        }
    }
}
