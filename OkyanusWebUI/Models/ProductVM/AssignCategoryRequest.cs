namespace OkyanusWebUI.Models.ProductVM
{
    public class AssignCategoryRequest
    {
        public int ProductID { get; set; }
        public List<int> CategoryIDs { get; set; }
    }
}
