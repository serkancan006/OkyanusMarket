using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Okyanus.DataAccessLayer.OptionsPattern;
using Okyanus.EntityLayer.Entities;
using Okyanus.EntityLayer.Entities.identitiy;

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

                    if (!context.Cities.Any())
                        context.Cities.AddRange(Cities);

                    //if (!context.Districts.Any())
                    //    context.Districts.AddRange(Districts);

                    if (!context.DeliveryTimes.Any())
                        context.DeliveryTimes.AddRange(DeliveryTimes);

                    if (!context.Markas.Any())
                        context.Markas.AddRange(Markas);

                    if (!context.ProductTypes.Any())
                        context.ProductTypes.AddRange(ProductTypes);

                    if (!context.Sliders.Any())
                        context.Sliders.AddRange(Sliders);

                    if (!context.Ssses.Any())
                        context.Ssses.AddRange(Ssses);

                    if (!context.TermsAndConditions.Any())
                        context.TermsAndConditions.AddRange(TermsAndConditions);

                    //if (!context.Products.Any())
                    //    context.Products.AddRange(Products);

                }

                context.SaveChanges();
            }
        }

        private static AppRole[] AppRoles = new[]
        {
            new AppRole { Name = "Admin", NormalizedName = "ADMIN" }
        };

        private static Group[] Groups = new[]
        {
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Yiyecekler",
                Description = "en lezzetli yiyecekler burada",
            },
              new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "İçecekler",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "1",
                ALTGRUP3 = "0",
                GRUPADI = "Asitli",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "0",
                GRUPADI = "Asitsiz",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "1",
                GRUPADI = "Sütler",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "2",
                ALTGRUP3 = "2",
                GRUPADI = "Meyve Suları",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Abur Cubur",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Salçalar",
            },
            new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Yağlar",
            },
              new Group()
            {
                ANAGRUP = "1",
                ALTGRUP1 = "5",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Yumurtalar",
            },
            new Group()
            {
                ANAGRUP = "2",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Manav",
                Description = "kaliteli manav ürünleri bulabilirsiniz",
            },
              new Group()
            {
                ANAGRUP = "2",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Meyveler",
            },
            new Group()
            {
                ANAGRUP = "2",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Sebzeler",
            },
            new Group()
            {
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Egzotik",
            },
            new Group()
            {
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Tropikal",
            },
            new Group()
            {
                ANAGRUP = "3",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Şarküteri",
                Description = "kaliteli kozmetik ürünleri bulabilirsiniz",
            },
            new Group()
            {
                ANAGRUP = "3",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Salamlar",
            },
            new Group()
            {
                ANAGRUP = "3",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Ballar",
            },
            new Group()
            {
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Zeytinler",
            },
            new Group()
            {
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Peynirler",
            },
            new Group()
            {
                ANAGRUP = "4",
                ALTGRUP1 = "0",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                GRUPADI = "Kozmetik",
                Description = "kaliteli kozmetik ürünleri bulabilirsiniz",
            },

        };

        private static About[] Abouts = new[]
        {
            new About()
            {
                AboutDesc = "Biz, [Şirket Adı], [kuruluş yılı] yılında [lokasyon] merkezli olarak kurulan bir [iş alanı] şirketiyiz. Müşterilerimize kaliteli ve yenilikçi [ürünler/hizmetler] sunarak sektörde öncü olmayı amaçlıyoruz. Tecrübeli ve uzman ekibimizle birlikte, müşteri memnuniyetini en üst seviyede tutmak için çalışıyoruz. Şeffaflık, dürüstlük ve müşteri odaklı yaklaşımımızla, her zaman müşterilerimizin ihtiyaçlarını karşılamayı ve beklentilerini aşmayı hedefliyoruz. [Şirket Adı] olarak, değerlerimize bağlı kalırken sürekli olarak yenilik ve gelişim peşindeyiz. Bizimle çalışan herkesin başarısını ve memnuniyetini ön planda tutarak, iş ortaklarımızla uzun vadeli ve karşılı",
                Misyon = "Bizim misyonumuz, müşterilerimize değer katmak ve onların ihtiyaçlarını en iyi şekilde karşılamaktır. Müşteri odaklı yaklaşımımızla, kaliteli ürünlerimiz ve hizmetlerimizle her zaman müşteri memnuniyetini sağlamak öncelikli hedefimizdir. İşimizi dürüstlük, şeffaflık ve etik değerlere bağlı kalarak yaparız. Sürdürülebilirlik ve toplumsal sorumluluk bilinciyle hareket eder, çevreye duyarlı çözümler üretmeyi önemseriz. Ekibimizle birlikte sürekli olarak yenilik ve gelişim peşindeyiz, sektörde öncü olmak için çalışıyoruz. Müşterilerimizin güvenini kazanmak ve onların başarısına katkıda bulunmak için varız.",
                Vizyon = "Biz, müşteri memnuniyetini en üst düzeye çıkarmak için çalışıyoruz ve yenilikçi çözümler sunarak sektörde lider konumumuzu korumayı hedefliyoruz. Biz, müşteri memnuniyetini en üst düzeye çıkarmak için çalışıyoruz ve yenilikçi çözümler sunarak sektörde lider konumumuzu korumayı hedefliyoruz."
            }
        };

        private static BranchUs[] Branches = new[]
        {
            new BranchUs()
            {
                BranchAdres = "Ankara, Kızılay, Ankara Caddesi 123, 06510"
            },
           new BranchUs()
            {
                BranchAdres = "Ankara, Kızılay, Başkent Sokak 456, 06510"
            },
            new BranchUs()
            {
                BranchAdres = "Ankara, Kızılay, Cumhuriyet Bulvarı 789, 06510"
            },
            new BranchUs()
            {
                BranchAdres = "İstanbul, Esener, Esenler Caddesi 123, 06510"
            },
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
                PhoneName = "Faks",
                PhoneNumber = "+90 312 123 45 67",
            },
            new MyPhone()
            {
                PhoneName = "Şirket-1",
                PhoneNumber = "+90 312 987 65 43",
            },
            new MyPhone()
            {
                PhoneName = "Şirket-2",
                PhoneNumber = "+90 312 987 65 44",
            },
            new MyPhone()
            {
                PhoneName = "Telefon",
                PhoneNumber = "+90 550 400 30 20",
            },
        };

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
                MediaName = "whatsapp",
                MediaUrl = "#",
            },
        };

        private static City[] Cities = new[]
        {
            new City()
            {
                CityName = "Ankara",
            }
        };

        private static District[] Districts = new[]
        {
            new District()
            {
                DistrictName = "Etimesgut",
                CityID = 5,
            }
        };

        private static DeliveryTime[] DeliveryTimes = new[]
        {
            new DeliveryTime()
            {
                DeliveryTimeName = "Genel",
                StartedTime = new TimeSpan(8,0,0),
                EndTime = new TimeSpan(20,0,0),
            }
        };

        private static Marka[] Markas = new[]
        {
            new Marka()
            {
                MarkaAdı = "Coca-Cola",
            },
               new Marka()
            {
                MarkaAdı = "Eti",
            },
            new Marka()
            {
                MarkaAdı = "Ülker",
            },
            new Marka()
            {
                MarkaAdı = "Bizim",
            },
            new Marka()
            {
                MarkaAdı = "Dimes",
            },
            new Marka()
            {
                MarkaAdı = "Pınar",
            },
            new Marka()
            {
                MarkaAdı = "Tamek",
            },
            new Marka()
            {
                MarkaAdı = "Aytaş",
            },
              new Marka()
            {
                MarkaAdı = "Didi",
            },
                new Marka()
            {
                MarkaAdı = "Çaykur",
            },
                  new Marka()
            {
                MarkaAdı = "Sütaş",
            },
                    new Marka()
            {
                MarkaAdı = "Tat",
            },
                      new Marka()
            {
                MarkaAdı = "Uludağ",
            },
        };

        private static ProductType[] ProductTypes = new[]
        {
            new ProductType()
            {
                Birim = "Adet",
                IncreaseAmount = 1,
            },
            new ProductType()
            {
                Birim = "Kg",
                IncreaseAmount = 0.1m,
            },
        };

        private static Slider[] Sliders = new[]
        {
            new Slider()
            {
                ImageUrl = "/web/images/ba.jpg",
            },
            new Slider()
            {
                ImageUrl = "/web/images/ba1.jpg",
            },
            new Slider()
            {
                ImageUrl = "/web/images/ba2.jpg",
            },
        };

        private static Sss[] Ssses = new[]
        {
            new Sss()
            {
                SssTitle = "Teslimatlarımız Nasıl Gerçekleşir?",
                SssContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Sss()
            {
                SssTitle = "Siparişiniz Ne kadar sürede ılaşır?",
                SssContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Sss()
            {
                SssTitle = "Sipariş takibi nasıl yapılır?",
                SssContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Sss()
            {
                SssTitle = "İade işlemi nasıl yapılır?",
                SssContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Sss()
            {
                SssTitle = "Online ödeme gelecek mi?",
                SssContent = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
        };

        private static TermsAndCondition[] TermsAndConditions = new[]
        {
            new TermsAndCondition()
            {
                Title = "Sipariş kabul şartlarımız",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
              new TermsAndCondition()
            {
                Title = "İade Şartlarımız",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
                new TermsAndCondition()
            {
                Title = "gizlilik politikamız",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
                  new TermsAndCondition()
            {
                Title = "Kullanıcı koşulları ve şartları",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
                    new TermsAndCondition()
            {
                Title = "Kullanılan ürünlerin iadesi",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },
                      new TermsAndCondition()
            {
                Title = "Sözleşmeler",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            },

        };

        private static Product[] Products = new[]
        {
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "1",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "2",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "3",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "1",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "4",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "1",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "5",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "1",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "6",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "7",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "8",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "9",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "10",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "11",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "1",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "12",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "13",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "14",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "15",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "1",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "16",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            //Category 2
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "2",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "17",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "2",
                ALTGRUP1 = "18",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "1",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "2",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "19",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "2",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "20",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "2",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "21",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "2",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "22",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "23",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "24",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "25",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "26",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "27",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "2",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "28",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "29",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "30",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "31",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "2",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "32",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            //Category 3
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "3",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "33",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "3",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "34",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "3",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "35",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "3",
                ALTGRUP1 = "1",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "36",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "3",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "37",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "3",
                ALTGRUP1 = "2",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "38",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "39",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "40",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "41",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "42",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "43",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "3",
                ALTGRUP1 = "3",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "44",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-1",
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "45",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-2",
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "46",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-3",
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "47",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
            new Product()
            {
                ProductName = "Ürün-4",
                ANAGRUP = "3",
                ALTGRUP1 = "4",
                ALTGRUP2 = "0",
                ALTGRUP3 = "0",
                AnaBarcode = "48",
                Price = 19.90m,
                DiscountedPrice = null,
                ImageUrl = null,
                MarkaID = 67,
                Stock = 50,
                ProductTypeID = 11,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
            },
        };

    }
}
