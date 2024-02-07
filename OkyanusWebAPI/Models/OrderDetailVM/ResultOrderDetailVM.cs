using Okyanus.EntityLayer.Entities;

namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class ResultOrderDetailVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
