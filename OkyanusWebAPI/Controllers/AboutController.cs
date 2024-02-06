using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        [HttpGet]
        public IActionResult actionResult()
        {
            return Ok();
        }
    }
}
