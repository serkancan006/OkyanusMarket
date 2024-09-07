using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class Marka : BaseEntity
    {
        public string MarkaAdı { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
