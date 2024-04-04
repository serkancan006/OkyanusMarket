namespace OkyanusWebAPI.Models.MyPhoneVM
{
    public class ResultMyPhoneVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string PhoneName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
