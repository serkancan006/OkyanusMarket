namespace OkyanusWebUI.Models.CategoryVM
{
    public class ResultCategoryVM
    {
        public string GRUPADI { get; set; }
        public bool Selected { get; set; }
        public string? Description { get; set; }

    }


    public class ResultGrupVM
    {
        public ResultCategoryVM[] anagroup { get; set; }
        public ResultCategoryVM[]? altgruP1 { get; set; }
        public ResultCategoryVM[]? altgruP2 { get; set; }
        public ResultCategoryVM[]? alTGRUP3 { get; set; }
    }
  


}
