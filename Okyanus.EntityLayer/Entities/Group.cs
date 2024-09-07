namespace Okyanus.EntityLayer.Entities
{
    public class Group
    {
        public string ANAGRUP { get; set; }
        public string ALTGRUP1 { get; set; }
        public string ALTGRUP2 { get; set; }
        public string ALTGRUP3 { get; set; }
        public string GRUPADI { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
