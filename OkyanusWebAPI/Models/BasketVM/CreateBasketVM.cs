namespace OkyanusWebAPI.Models.BasketVM
{
    public class CreateBasketVM
    {
        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
    }
}
