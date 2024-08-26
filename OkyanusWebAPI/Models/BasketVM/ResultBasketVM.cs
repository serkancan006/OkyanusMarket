using Okyanus.EntityLayer.Entities;

namespace OkyanusWebAPI.Models.BasketVM
{
    public class ResultBasketVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public Guid ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
