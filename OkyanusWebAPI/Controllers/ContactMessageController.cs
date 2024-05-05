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
        public IActionResult ContactMessageList()
        {
            var values = _ContactMessageService.TGetListAll();
            var result = _mapper.Map<List<ResultContactMessageVM>>(values);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddContactMessage(CreateContactMessageVM ContactMessageVM)
        {
            var value = _mapper.Map<ContactMessage>(ContactMessageVM);
            _ContactMessageService.TAdd(value);
            return Ok("ContactMessage Eklendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteContactMessage(int id)
        {
            var values = _ContactMessageService.TGetByID(id);
            _ContactMessageService.TDelete(values);
            return Ok("ContactMessage Silindi");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateContactMessage(UpdateContactMessageVM ContactMessageVM)
        {
            var value = _mapper.Map<ContactMessage>(ContactMessageVM);
            _ContactMessageService.TUpdate(value);
            return Ok("ContactMessage Güncellendi");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public IActionResult GetContactMessage(int id)
        {
            var values = _ContactMessageService.TGetByID(id);
            var result = _mapper.Map<ResultContactMessageVM>(values);
            return Ok(result);
        }
    }
}
