namespace OkyanusWebUI.Models.OrderVM
{
    public class CreateOrderVmApi
    {
        public string? description { get; set; }
        public int userAdresID { get; set; }
        public string telefonNo { get; set; }
        public string teslimatYontemi { get; set; }
        public string teslimatSaati { get; set; }
        public string alternatifUrun { get; set; }
        public List<Orderitem> orderItems { get; set; }

        public class Orderitem
        {
            public string productId { get; set; }
            public decimal quantity { get; set; }
        }

    }
}
