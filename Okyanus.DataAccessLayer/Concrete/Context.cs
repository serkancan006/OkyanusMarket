using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<BranchUs> BranchUses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Basket> Baskets { get; set; }



        //Interceptor
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            baseEntity.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            //baseEntity.Status = true;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            entry.Property("CreatedDate").IsModified = false;
                            break;
                        default:
                            // Bilinmeyen bir durumla karşılaşıldığında yapılacaklar
                            break;
                    }
                }

                if (entry.Entity is AppUser appUser)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            appUser.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            appUser.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            appUser.Status = true;
                            break;
                        case EntityState.Modified:
                            appUser.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            entry.Property("CreatedDate").IsModified = false;
                            break;
                        default:
                            // Bilinmeyen bir durumla karşılaşıldığında yapılacaklar
                            break;
                    }
                }
            }

            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
