namespace OkyanusWebAPI.Models.BasketVM
{
    public class CreateBasketVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
    }
}
