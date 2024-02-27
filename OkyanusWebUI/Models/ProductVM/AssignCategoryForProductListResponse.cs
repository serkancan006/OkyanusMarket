namespace OkyanusWebUI.Models.ProductVM
{
    public class AssignCategoryForProductListResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public List<AssignCategoryForProduct> ProductCategories { get; set; }
    }
}
