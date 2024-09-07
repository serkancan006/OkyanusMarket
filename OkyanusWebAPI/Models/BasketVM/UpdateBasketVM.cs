namespace OkyanusWebAPI.Models.BasketVM
{
    public class UpdateBasketVM
    {
        public int ID { get; set; }

        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public string ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
