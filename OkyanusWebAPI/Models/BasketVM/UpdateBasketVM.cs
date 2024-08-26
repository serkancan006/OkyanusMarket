using Okyanus.EntityLayer.Entities;

namespace OkyanusWebAPI.Models.BasketVM
{
    public class UpdateBasketVM
    {
        public Guid ID { get; set; }

        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
