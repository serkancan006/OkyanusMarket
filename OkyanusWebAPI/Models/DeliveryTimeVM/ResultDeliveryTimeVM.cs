namespace OkyanusWebAPI.Models.DeliveryTimeVM
{
    public class ResultDeliveryTimeVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string? DeliveryTimeName { get; set; }
        public TimeSpan StartedTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
