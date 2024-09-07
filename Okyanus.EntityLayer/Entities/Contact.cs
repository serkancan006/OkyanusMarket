using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class Contact : BaseEntity
    {
        public string Title { get; set; }
        public string Adres { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string MapLocation { get; set; }
    }
}
