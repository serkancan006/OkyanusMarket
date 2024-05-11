namespace OkyanusWebAPI.Models.DeliveryTimeVM
{
    public class CreateDeliveryTimeVM
    {
        public string? DeliveryTimeName { get; set; }
        public TimeSpan StartedTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
