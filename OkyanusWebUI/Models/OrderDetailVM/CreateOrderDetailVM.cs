namespace OkyanusWebUI.Models.OrderDetailVM
{
    public class CreateOrderDetailVM
    {
        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
