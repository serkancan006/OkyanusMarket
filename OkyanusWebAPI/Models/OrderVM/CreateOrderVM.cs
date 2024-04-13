namespace OkyanusWebAPI.Models.OrderVM
{
    public class CreateOrderVM
    {
        public string? Description { get; set; }
        public double TotalPrice { get; set; }

        public string TeslimatYontemi { get; set; }
        public string TeslimatSaati { get; set; }
        public string AlternatifUrun { get; set; }

        //public string OrderFirstName { get; set; }
        //public string OrderSurname { get; set; }
        //public string OrderMail { get; set; }
        public string OrderPhone { get; set; }

        public string OrderAdress { get; set; }
        public string OrderApartman { get; set; }
        public string OrderDaire { get; set; }
        public string OrderKat { get; set; }
        public string OrderSehir { get; set; }
        public string OrderIlce { get; set; }
    }
}
