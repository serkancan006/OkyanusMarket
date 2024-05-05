namespace OkyanusWebAPI.Models.SssVM
{
    public class ResultSssVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string SssTitle { get; set; }
        public string SssContent { get; set; }
    }
}
