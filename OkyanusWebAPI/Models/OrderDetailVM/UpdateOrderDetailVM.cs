namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class UpdateOrderDetailVM
    {
        public int ID { get; set; }

        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
