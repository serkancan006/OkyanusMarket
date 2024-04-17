namespace OkyanusWebUI.Areas.Admin.Models.AdminGroupVM
{
    public class ResultGroupVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }


        public string ANAGRUP { get; set; }
        public string ALTGRUP1 { get; set; } 
        public string ALTGRUP2 { get; set; } 
        public string ALTGRUP3 { get; set; } 
        public string GRUPADI { get; set; }
    }
}
