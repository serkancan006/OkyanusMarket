using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Config
{
    public class FavoriUrunlerConfig : IEntityTypeConfiguration<FavoriUrunler>
    {
        public void Configure(EntityTypeBuilder<FavoriUrunler> builder)
        {
            builder
                .HasOne<Product>(sc => sc.Product)
                .WithMany(s => s.FavoriUrunlers)
                .HasForeignKey(sc => sc.ProductID);

            builder
               .HasOne<AppUser>(sc => sc.AppUser)
               .WithMany(s => s.FavoriUrunlers)
               .HasForeignKey(sc => sc.AppUserID);
        }
    }
}
