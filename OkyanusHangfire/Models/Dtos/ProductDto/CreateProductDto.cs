namespace OkyanusHangfire.Models.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string ID { get; set; } = new Guid().ToString();
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public decimal Stock { get; set; }
        public string AnaBarcode { get; set; }
        public string ANAGRUP { get; set; }
        public string? ALTGRUP1 { get; set; }
        public string? ALTGRUP2 { get; set; }
        public string? ALTGRUP3 { get; set; }
        public int MarkaID { get; set; }
        public int ProductTypeID { get; set; }
        //public DateTime CreatedDate { get; set; } = DateTime.Now;
        //public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
    }
}
