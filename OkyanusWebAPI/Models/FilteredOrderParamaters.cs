namespace OkyanusWebAPI.Models
{
    public class FilteredOrderParamaters
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 20;
        public string? OrderStatus { get; set; }
    }
}
