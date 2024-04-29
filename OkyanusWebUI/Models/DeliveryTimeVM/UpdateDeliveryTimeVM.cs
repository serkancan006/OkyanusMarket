namespace OkyanusWebUI.Models.DeliveryTimeVM
{
    public class UpdateDeliveryTimeVM
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

        public string? DeliveryTimeName { get; set; }
        public DateTime StartedTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
