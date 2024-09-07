using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public virtual List<District> Districts { get; set; }
    }
}
