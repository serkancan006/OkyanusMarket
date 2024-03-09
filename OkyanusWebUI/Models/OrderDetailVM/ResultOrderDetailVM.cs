using OkyanusWebUI.Models.ProductVM;

namespace OkyanusWebUI.Models.OrderDetailVM
{
    public class ResultOrderDetailVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public double Count { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public ResultProductVM Product { get; set; }
    }
}
