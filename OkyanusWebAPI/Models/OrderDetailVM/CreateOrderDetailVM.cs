namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class CreateOrderDetailVM
    {
        public double Count { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice => UnitPrice * Count;
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
