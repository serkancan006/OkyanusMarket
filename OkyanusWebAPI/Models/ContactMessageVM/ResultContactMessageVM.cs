namespace OkyanusWebAPI.Models.ContactMessageVM
{
    public class ResultContactMessageVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
