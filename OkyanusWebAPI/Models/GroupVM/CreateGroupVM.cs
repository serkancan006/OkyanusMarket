namespace OkyanusWebAPI.Models.GroupVM
{
    public class CreateGroupVM
    {
        public string ANAGRUP { get; set; }
        public string? ALTGRUP1 { get; set; } = "0";
        public string? ALTGRUP2 { get; set; } = "0";
        public string? ALTGRUP3 { get; set; } = "0";
        public string GRUPADI { get; set; }
    }
}
