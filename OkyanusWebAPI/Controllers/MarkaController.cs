using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.MarkaVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        private readonly IMarkaService _MarkaService;
        private readonly IMapper _mapper;

        public MarkaController(IMarkaService MarkaService, IMapper mapper)
        {
            _MarkaService = MarkaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult MarkaList()
        {
            var values = _MarkaService.TGetListAll();
            var result = _mapper.Map<List<ResultMarkaVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMarka(CreateMarkaVM MarkaVM)
        {
            var value = _mapper.Map<Marka>(MarkaVM);
            _MarkaService.TAdd(value);
            return Ok("Marka Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMarka(int id)
        {
            var values = _MarkaService.TGetByID(id);
            _MarkaService.TDelete(values);
            return Ok("Marka Silindi");
        }

        [HttpPut]
        public IActionResult UpdateMarka(UpdateMarkaVM MarkaVM)
        {
            var value = _mapper.Map<Marka>(MarkaVM);
            _MarkaService.TUpdate(value);
            return Ok("Marka Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMarka(int id)
        {
            var values = _MarkaService.TGetByID(id);
            var result = _mapper.Map<ResultMarkaVM>(values);
            return Ok(result);
        }
    }
}
