namespace OkyanusWebUI.Models.ProductVM
{
    public class AssignCategoryForProductListResponse
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string SecilenCategoryAdı { get; set; } //radio button ile eklendi
        public List<AssignCategoryForProduct> ProductCategories { get; set; }
    }
}
