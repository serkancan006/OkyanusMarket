namespace OkyanusWebAPI.Models.ProductVM
{
    public class AssignCategoryRequest
    {
        public int ProductID { get; set; }
        //public List<int> CategoryIDs { get; set; }
        public int CategoryID { get; set; }
    }
}
