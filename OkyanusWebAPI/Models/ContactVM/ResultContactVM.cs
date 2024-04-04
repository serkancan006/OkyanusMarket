namespace OkyanusWebAPI.Models.ContactVM
{
    public class ResultContactVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string Title { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
    }
}
