namespace OkyanusWebUI.Models.ProductVM
{
    public class AssignCategoryForProductListResponse
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SecilenCategoryID { get; set; } //radio button ile eklendi
        public List<AssignCategoryForProduct> ProductCategories { get; set; }
    }
}
