using Microsoft.AspNetCore.Mvc;

namespace OkyanusWebUI.Controllers
{
    public class GroupController : Controller
    {
        [HttpGet]
        public IActionResult GetCategorySidebarComponent(int? categoryID = null)
        {
            if (categoryID == null)
            {
                return ViewComponent("_ProductSidebarPartial");
            }
            return ViewComponent("_ProductSidebarPartial", new { categoryID = categoryID });
        }
    }
}
