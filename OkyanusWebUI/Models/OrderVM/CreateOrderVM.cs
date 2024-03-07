using OkyanusWebUI.Service;

namespace OkyanusWebUI.Models.OrderVM
{
    public class CreateOrderVM
    {
        public string? Description { get; set; }
        public double? TotalPrice { get; set; }

        public string? OrderFirstName { get; set; }
        public string? OrderSurname { get; set; }
        public string? OrderMail { get; set; }
        public string? OrderPhone { get; set; }

        public string? OrderAdress { get; set; }
        public string? OrderApartmanNo { get; set; }
        public string? OrderDaireNo { get; set; }
        public string? OrderKat { get; set; }
        public string? OrderSehir { get; set; }
        public string? OrderIlce { get; set; }

        public List<CartItem>? OrderItems { get; set; }
    }
}
