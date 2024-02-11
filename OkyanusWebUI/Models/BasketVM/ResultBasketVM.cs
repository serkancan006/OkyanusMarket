namespace OkyanusWebUI.Models.BasketVM
{
    public class ResultBasketVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public double Price { get; set; }
        public double Count { get; set; }
        public double TotalPrice { get; set; }
        public int ProductID { get; set; }
        //public Product Product { get; set; }
    }
}
