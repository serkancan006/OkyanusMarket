using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class Basket : BaseEntity
    {
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductID { get; set; }
        public Product Product { get; set; }
    }
}
