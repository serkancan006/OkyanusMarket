namespace OkyanusWebAPI.Models.OrderVM
{
    public class CreateOrderRequestVM
    {
        public string? Description { get; set; }

        //public string OrderFirstName { get; set; }
        //public string OrderSurname { get; set; }
        //public string OrderMail { get; set; }
        //public string OrderPhone { get; set; }

        public int UserAdresID { get; set; }
        public string TelefonNo { get; set; }
        public string TeslimatYontemi { get; set; }
        public string TeslimatSaati { get; set; }
        public string AlternatifUrun { get; set; }

        public List<CartItem> OrderItems { get; set; }
    }
    public class CartItem
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        //public double TotalPrice => Price * Quantity;
        //public double TotalPrice
        //{
        //    get
        //    {
        //        return Price * Quantity;
        //    }
        //}
    }
}
