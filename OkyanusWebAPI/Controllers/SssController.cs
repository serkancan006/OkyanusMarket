using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.SssVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SssController : ControllerBase
    {
        private readonly ISssService _SssService;
        private readonly IMapper _mapper;

        public SssController(ISssService SssService, IMapper mapper)
        {
            _SssService = SssService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SssList()
        {
            var values = _SssService.TGetListAll();
            var result = _mapper.Map<List<ResultSssVM>>(values);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddSss(CreateSssVM SssVM)
        {
            var value = _mapper.Map<Sss>(SssVM);
            _SssService.TAdd(value);
            return Ok("Sss Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteSss(int id)
        {
            var values = _SssService.TGetByID(id);
            _SssService.TDelete(values);
            return Ok("Sss Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateSss(UpdateSssVM SssVM)
        {
            var value = _mapper.Map<Sss>(SssVM);
            _SssService.TUpdate(value);
            return Ok("Sss Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSss(int id)
        {
            var values = _SssService.TGetByID(id);
            var result = _mapper.Map<ResultSssVM>(values);
            return Ok(result);
        }
    }
}
