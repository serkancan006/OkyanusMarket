namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class UpdateOrderDetailVM
    {
        public int ID { get; set; }

        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
