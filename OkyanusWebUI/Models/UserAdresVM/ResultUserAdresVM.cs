namespace OkyanusWebUI.Models.UserAdresVM
{
    public class ResultUserAdresVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string UserAdress { get; set; }
        public string UserApartman { get; set; }
        public string UserDaire { get; set; }
        public string UserKat { get; set; }
        public string UserSehir { get; set; }
        public string UserIlce { get; set; }
        public bool Selected { get; set; }

    }
}
