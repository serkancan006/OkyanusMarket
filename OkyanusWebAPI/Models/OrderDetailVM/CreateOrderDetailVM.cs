﻿namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class CreateOrderDetailVM
    {
        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Count;
        public string ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
