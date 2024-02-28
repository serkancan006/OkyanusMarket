namespace OkyanusWebUI.Models.ProductVM
{
    public class ChangeProductImageRequest
    {
        public IFormFile? FormFile { get; set; }
        public int ProductID { get; set; }
    }
}
