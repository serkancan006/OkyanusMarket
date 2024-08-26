using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.ProductVM;

namespace OkyanusWebAPI.Models.OrderDetailVM
{
    public class ResultOrderDetailVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public decimal Count { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public Guid ProductID { get; set; }
        public int OrderID { get; set; }
        public ResultProductVM Product { get; set; }
    }
}
