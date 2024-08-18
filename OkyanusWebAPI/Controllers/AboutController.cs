﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.AboutVM;
using OkyanusWebAPI.Models.BasketVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;
        private readonly IMapper _mapper;
        private readonly IOlimposSoapService _olimposSoapService;
        public AboutController(IAboutService AboutService, IMapper mapper, IOlimposSoapService olimposSoapService)
        {
            _AboutService = AboutService;
            _mapper = mapper;
            _olimposSoapService = olimposSoapService;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _AboutService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultAboutVM>>(values);
            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult AddAbout(CreateAboutVM AboutVM)
        //{
        //    var value = _mapper.Map<About>(AboutVM);
        //    _AboutService.TAdd(value);
        //    return Ok("About Eklendi");
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteAbout(int id)
        //{
        //    var values = _AboutService.TGetByID(id);
        //    _AboutService.TDelete(values);
        //    return Ok("About Silindi");
        //}

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutVM AboutVM)
        {
            var value = _mapper.Map<About>(AboutVM);
            await _AboutService.TUpdateAsync(value);
            return Ok("About Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values = await _AboutService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultAboutVM>(values);
            return Ok(result);
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetProductListSoap()
        //{
        //    var result = await _olimposSoapService.GetProductAllListSoap();
        //    return Ok(result.Data);
        //}

    }
}
