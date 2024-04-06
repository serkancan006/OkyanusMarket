namespace OkyanusWebUI.Models.ProductVM
{
    public class CreateProductVM
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public int GroupID { get; set; }
        public string Marka { get; set; }
        public string AnaBarcode { get; set; }
        public Birim ProductType { get; set; }  
    }
}
