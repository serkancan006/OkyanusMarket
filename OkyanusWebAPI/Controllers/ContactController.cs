using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.ContactVM;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _ContactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService ContactService, IMapper mapper)
        {
            _ContactService = ContactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _ContactService.TGetListAll();
            var result = _mapper.Map<List<ResultContactVM>>(values);
            return Ok(result);
        }

        //[HttpPost]
        //public IActionResult AddContact(CreateContactVM ContactVM)
        //{
        //    var value = _mapper.Map<Contact>(ContactVM);
        //    _ContactService.TAdd(value);
        //    return Ok("Contact Eklendi");
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteContact(int id)
        //{
        //    var values = _ContactService.TGetByID(id);
        //    _ContactService.TDelete(values);
        //    return Ok("Contact Silindi");
        //}

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactVM ContactVM)
        {
            var value = _mapper.Map<Contact>(ContactVM);
            _ContactService.TUpdate(value);
            return Ok("Contact Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _ContactService.TGetByID(id);
            var result = _mapper.Map<ResultContactVM>(values);
            return Ok(result);
        }
    }
}
