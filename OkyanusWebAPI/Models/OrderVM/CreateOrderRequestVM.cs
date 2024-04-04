namespace OkyanusWebAPI.Models.OrderVM
{
    public class CreateOrderRequestVM
    {
        public string? Description { get; set; }

        public string OrderFirstName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderMail { get; set; }
        public string OrderPhone { get; set; }

        public string OrderAdress { get; set; }
        public string OrderApartmanNo { get; set; }
        public string OrderDaireNo { get; set; }
        public string OrderKat { get; set; }
        public string OrderSehir { get; set; }
        public string OrderIlce { get; set; }

        public List<CartItem> OrderItems { get; set; }
    }
    public class CartItem
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
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
