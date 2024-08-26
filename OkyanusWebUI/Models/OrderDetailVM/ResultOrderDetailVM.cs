using OkyanusWebUI.Models.ProductVM;

namespace OkyanusWebUI.Models.OrderDetailVM
{
    public class ResultOrderDetailVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductID { get; set; }
        public int OrderID { get; set; }
        public ResultProductVM Product { get; set; }
    }
}
