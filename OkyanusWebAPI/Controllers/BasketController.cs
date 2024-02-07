using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.BasketVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _BasketService;
        private readonly IMapper _mapper;

        public BasketController(IBasketService BasketService, IMapper mapper)
        {
            _BasketService = BasketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BasketList()
        {
            var values = _BasketService.TGetListAll();
            var result = _mapper.Map<List<ResultBasketVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBasket(CreateBasketVM BasketVM)
        {
            var value = _mapper.Map<Basket>(BasketVM);
            _BasketService.TAdd(value);
            return Ok("Basket Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var values = _BasketService.TGetByID(id);
            _BasketService.TDelete(values);
            return Ok("Basket Silindi");
        }

        [HttpPut]
        public IActionResult UpdateBasket(UpdateBasketVM BasketVM)
        {
            var value = _mapper.Map<Basket>(BasketVM);
            _BasketService.TUpdate(value);
            return Ok("Basket Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBasket(int id)
        {
            var values = _BasketService.TGetByID(id);
            var result = _mapper.Map<ResultBasketVM>(values);
            return Ok(result);
        }
    }
}
