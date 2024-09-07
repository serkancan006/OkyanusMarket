using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;

namespace Okyanus.EntityLayer.Entities
{
    public class FavoriUrunler : BaseEntity
    {
        public string ProductID { get; set; }
        public Product Product { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
