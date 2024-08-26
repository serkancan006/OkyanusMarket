namespace OkyanusWebAPI.Models.ProductVM
{
    public class ChangeProductImageRequest
    {
        public string? ImagePath { get; set; }
        public Guid ProductID { get; set; }
    }
}
