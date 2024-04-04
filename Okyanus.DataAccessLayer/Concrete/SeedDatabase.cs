using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Okyanus.DataAccessLayer.OptionsPattern;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;
using System;
using System.Linq;

namespace Okyanus.DataAccessLayer.Concrete
{
    public static class SeedDatabase
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                //ıoc den gerkeli servislerin örnekleri alınır
                var context = services.GetRequiredService<Context>(); 
                var mailOptions = services.GetRequiredService<IOptions<MailOptions>>().Value;

                if (!context.Database.GetPendingMigrations().Any()) //migrationlar uygulandıktan sonra bu işi yapar
                {
                    if (!context.Roles.Any())
                        context.Roles.AddRange(AppRoles);

                    if (!context.Users.Any())
                        context.Users.AddRange(AppUsers(mailOptions));

                    if (!context.UserRoles.Any())
                        context.UserRoles.AddRange(UserRoles);

                    if (!context.Groups.Any())
                        context.Groups.AddRange(Groups);

                    if (!context.Abouts.Any())
                        context.Abouts.AddRange(Abouts);

                    if (!context.BranchUses.Any())
                        context.BranchUses.AddRange(Branches);

                    if (!context.Contacts.Any())
                        context.Contacts.AddRange(Contacts(mailOptions));

                    if (!context.MyPhones.Any())
                        context.MyPhones.AddRange(MyPhones);

                    if (!context.SocialMedias.Any())
                        context.SocialMedias.AddRange(SocialMedias);

                }

                context.SaveChanges();
            }
        }

        private static AppRole[] AppRoles = new[]
        {
            new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" }
        };
        private static AppUser[] AppUsers(MailOptions mailOptions)
        {
            return new[]
            {
                new AppUser
                {
                    Id = 1,
                    Name = "Admin",
                    Surname = mailOptions.MailName,
                    UserName = "okyanusrootadmin", // Kullanıcı adı
                    NormalizedUserName = "OKYANUSROOTADMIN",
                    Email = mailOptions.MailAdress, // E-posta
                    NormalizedEmail = mailOptions.MailAdress.ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "123456Aa*"), // Hashlenmiş şifre
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    // Diğer kullanıcı özellikleri
                }
            };
        }

        private static IdentityUserRole<int>[] UserRoles = new[]
        {
            new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            }
        };

        private static Group[] Groups = new[]
        {
            new Group()
            {
                ID = 1,
                ANAGRUP = "1",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Yiyecekler",
                Description = "en lezzetli yiyecekler burada",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 2,
                ANAGRUP = "2",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Kozmetik",
                Description = "kaliteli kozmetik ürünleri bulabilirsiniz",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 3,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Manav",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 4,
                ANAGRUP = "1",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "İçecekler",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 5,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "1",
                ALTGRUP3 = "0",
                GRUPADI = "Meyveler",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 6,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "0",
                GRUPADI = "Sebzeler",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 7,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "1",
                ALTGRUP3 = "1",
                GRUPADI = "Meyve Kg",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 8,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "1",
                ALTGRUP3 = "2",
                GRUPADI = "Meyve Adet",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 9,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "1",
                GRUPADI = "Sebze Kg",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            },
            new Group()
            {
                ID = 10,
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "2",
                GRUPADI = "Sebze Adet",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Status = true
            }
        };

        private static About[] Abouts = new[]
        {
            new About()
            {
                AboutDesc = "asfasfa",
                Misyon = "asfafa",
                Vizyon = "asfasfafa"
            }
        };

        private static BranchUs[] Branches = new[]
        {
            new BranchUs()
            {
                BranchAdres = "Ankara, Kızılay, Ankara Caddesi 123, 06510"
            }
        };
        private static Contact[] Contacts(MailOptions mailOptions)
        {
            return new[]
            {
                new Contact()
                {
                    Adres = "Ankara, Kızılay, Ankara Caddesi 123, 06510",
                    Mail = mailOptions.MailAdress,
                    MapLocation = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3020.345949125132!2d32.85446491576448!3d39.920641792035056!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14d34b4c1ecf1729%3A0x48f0b07b2cf09b64!2sK%C4%B1z%C4%B1lay%2C%20Ankara!5e0!3m2!1sen!2str!4v1649839298684!5m2!1sen!2str",
                    Phone = "0550 400 30 20",
                    Title = "İletişim Başlıgı",
                }
            };
        }

        private static MyPhone[] MyPhones = new[]
        {
            new MyPhone()
            {
                PhoneName = "Fax",
                PhoneNumber = "+90 312 123 45 67",
            },
            new MyPhone()
            {
                PhoneName = "Telefon",
                PhoneNumber = "+90 312 987 65 43",
            },
        };
        //product Slider
        private static SocialMedia[] SocialMedias = new[]
        {
            new SocialMedia()
            {
                MediaName = "instagram",
                MediaUrl = "#",
            },
            new SocialMedia()
            {
                MediaName = "facebook",
                MediaUrl = "#",
            },
             new SocialMedia()
            {
                MediaName = "twitter",
                MediaUrl = "#",
            },
              new SocialMedia()
            {
                MediaName = "pinterest",
                MediaUrl = "#",
            },
        };


    }
}
