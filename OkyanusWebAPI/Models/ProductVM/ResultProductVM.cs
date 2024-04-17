namespace OkyanusWebAPI.Models.ProductVM
{
    public class ResultProductVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string ProductName { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string Description { get; set; }
        public Birim ProductType { get; set; }
        public int Stock { get; set; }

        public string ANAGRUP { get; set; }
        public string? ALTGRUP1 { get; set; } = "0";
        public string? ALTGRUP2 { get; set; } = "0";
        public string? ALTGRUP3 { get; set; } = "0";
        public string Marka { get; set; }
        public string AnaBarcode { get; set; }
    }
}
