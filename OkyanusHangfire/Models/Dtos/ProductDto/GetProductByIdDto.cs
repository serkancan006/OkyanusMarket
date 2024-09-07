namespace OkyanusHangfire.Models.Dtos.ProductDto
{
    public class GetProductByIdDto
    {
        public string ID { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
