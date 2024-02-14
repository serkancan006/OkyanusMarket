﻿namespace OkyanusWebAPI.Models.ProductVM
{
    public class CreateProductVM
    {
        public string ProductName { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Birim ProductType { get; set; }
    }
}
