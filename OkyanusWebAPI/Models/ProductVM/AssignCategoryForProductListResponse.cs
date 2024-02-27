namespace OkyanusWebAPI.Models.ProductVM
{
    public class AssignCategoryForProductListResponse
    {
        public string? ProductName { get; set; }
        public List<AssignCategoryForProduct> ProductCategories { get; set; }
    }
}
