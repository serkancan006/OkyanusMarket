using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.ContactMessageVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMessageController : ControllerBase
    {
        private readonly IContactMessageService _ContactMessageService;
        private readonly IMapper _mapper;

        public ContactMessageController(IContactMessageService ContactMessageService, IMapper mapper)
        {
            _ContactMessageService = ContactMessageService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> ContactMessageList()
        {
            var values = await _ContactMessageService.TGetListAllAsync();
            var result = _mapper.Map<List<ResultContactMessageVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddContactMessage(CreateContactMessageVM ContactMessageVM)
        {
            var value = _mapper.Map<ContactMessage>(ContactMessageVM);
            await _ContactMessageService.TAddAsync(value);
            return Ok("ContactMessage Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            var values = await _ContactMessageService.TGetByIDAsync(id);
            await _ContactMessageService.TDeleteAsync(values);
            return Ok("ContactMessage Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateContactMessage(UpdateContactMessageVM ContactMessageVM)
        {
            var value = _mapper.Map<ContactMessage>(ContactMessageVM);
            await _ContactMessageService.TUpdateAsync(value);
            return Ok("ContactMessage Güncellendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactMessage(int id)
        {
            var values = await _ContactMessageService.TGetByIDAsync(id);
            var result = _mapper.Map<ResultContactMessageVM>(values);
            return Ok(result);
        }
    }
}
