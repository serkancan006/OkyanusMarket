using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Okyanus.DataAccessLayer.OptionsPattern;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.Common;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }
        //public DbSet<Basket> Baskets { get; set; }
        public DbSet<BranchUs> BranchUses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<MyPhone> MyPhones { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<UserAdres> UserAdreses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<DeliveryTime> DeliveryTimes { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sss> Ssses { get; set; }
        public DbSet<TermsAndCondition> TermsAndConditions { get; set; }
        


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
                            baseEntity.Status = true;
                            break;
                        case EntityState.Modified:
                            baseEntity.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                            entry.Property("CreatedDate").IsModified = false;
                            entry.Property("Status").IsModified = false;
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
