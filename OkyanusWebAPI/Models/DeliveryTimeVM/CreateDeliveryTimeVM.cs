namespace OkyanusWebAPI.Models.DeliveryTimeVM
{
    public class CreateDeliveryTimeVM
    {
        public string? DeliveryTimeName { get; set; }
        public DateTime StartedTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
