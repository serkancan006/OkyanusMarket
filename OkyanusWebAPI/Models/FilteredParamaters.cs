namespace OkyanusWebAPI.Models
{
    public class FilteredParamaters
    {
        public string? searchName { get; set; }
        public string? markaAdi { get; set; }
        public string? categoryName { get; set; }
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public string? sortField { get; set; } // Sıralama alanı
        public string? sortOrder { get; set; } // Sıralama düzeni (artan/azalan)
    }
}
