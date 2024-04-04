namespace OkyanusWebAPI.Models.GroupVM
{
    public class ResultGroupVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string ANAGRUP { get; set; }
        public string ALTGRUP1 { get; set; } = "0";
        public string ALTGRUP2 { get; set; } = "0";
        public string ALTGRUP3 { get; set; } = "0";
        public string GRUPADI { get; set; }
    }
}
