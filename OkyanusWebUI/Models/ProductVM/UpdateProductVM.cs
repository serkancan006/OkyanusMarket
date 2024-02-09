﻿namespace OkyanusWebUI.Models.ProductVM
{
    public class UpdateProductVM
    {
        public int ID { get; set; }

        public string ProductName { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public double? DiscountedPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public bool ProductType { get; set; }  // 0 => adet -- 1 => kg
    }
}
