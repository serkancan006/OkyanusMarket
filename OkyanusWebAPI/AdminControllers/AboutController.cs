using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebAPI.AdminControllers
{
    [Route("api/admin/[controller]")]
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
