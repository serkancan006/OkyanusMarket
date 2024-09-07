using Okyanus.EntityLayer.Entities.Common;

namespace Okyanus.EntityLayer.Entities
{
    public class District : BaseEntity
    {
        public string DistrictName { get; set; }
        public int CityID { get; set; }
        public City City { get; set; }
    }
}
