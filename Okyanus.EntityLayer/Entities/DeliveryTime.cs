using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class DeliveryTime : BaseEntity
    {
        public string? DeliveryTimeName { get; set; }
        public TimeSpan StartedTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
