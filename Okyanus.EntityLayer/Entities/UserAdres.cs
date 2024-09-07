using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;

namespace Okyanus.EntityLayer.Entities
{
    public class UserAdres : BaseEntity
    {
        public string UserAdress { get; set; }
        public string UserApartman { get; set; }
        public string UserDaire { get; set; }
        public string UserKat { get; set; }
        public string UserSehir { get; set; }
        public string UserIlce { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
