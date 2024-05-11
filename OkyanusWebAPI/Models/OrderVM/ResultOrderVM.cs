namespace OkyanusWebAPI.Models.OrderVM
{
    public class ResultOrderVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
        public string OrderStatus { get; set; }



        public string Description { get; set; }
        public decimal TotalPrice { get; set; }

        public string OrderFirstName { get; set; }
        public string OrderSurname { get; set; }
        public string OrderMail { get; set; }
        public string OrderPhone { get; set; }

        public string OrderAdress { get; set; }
        public string OrderApartman { get; set; }
        public string OrderDaire { get; set; }
        public string OrderKat { get; set; }
        public string OrderSehir { get; set; }
        public string OrderIlce { get; set; }


      
        public List<OrderDetailVM.ResultOrderDetailVM> OrderDetails { get; set; }

        public string TeslimatYontemi { get; set; }
        public string TeslimatSaati { get; set; }
        public string AlternatifUrun { get; set; }
        public string OrderUserPhone { get; set; }

      

        //public int? AppUserID { get; set; }
    }
}
