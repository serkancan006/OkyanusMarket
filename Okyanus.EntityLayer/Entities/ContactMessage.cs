using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class ContactMessage : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
