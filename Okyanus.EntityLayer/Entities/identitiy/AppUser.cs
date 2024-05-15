using Microsoft.AspNetCore.Identity;

namespace Okyanus.EntityLayer.Entities.identitiy
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime CreatedDate { get; set; }
        virtual public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<UserAdres> UserAdreses { get; set; }
        public virtual List<FavoriUrunler> FavoriUrunlers { get; set; }

    }
}
