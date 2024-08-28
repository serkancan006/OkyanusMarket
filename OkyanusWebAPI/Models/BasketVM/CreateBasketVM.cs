using Okyanus.EntityLayer.Entities;

namespace OkyanusWebAPI.Models.BasketVM
{
    public class CreateBasketVM
    {
        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public string ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
