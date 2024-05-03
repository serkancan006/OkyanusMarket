﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Okyanus.DataAccessLayer.Concrete;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Okyanus.DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240502133334_mig_9")]
    partial class mig_9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("RoleId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("RoleId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Value")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.About", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AboutDesc")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Misyon")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Vizyon")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.BranchUs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("BranchAdres")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("BranchUses");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MapLocation")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.ContactMessage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("ContactMessages");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.DeliveryTime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("DeliveryTimeName")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("StartedTime")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("DeliveryTimes");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.District", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CityID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Group", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ALTGRUP1")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ALTGRUP2")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ALTGRUP3")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ANAGRUP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("GRUPADI")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.HasIndex("ANAGRUP", "ALTGRUP1", "ALTGRUP2", "ALTGRUP3", "GRUPADI")
                        .IsUnique();

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.identitiy.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("\"NormalizedName\" IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.identitiy.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TIMESTAMP(7) WITH TIME ZONE");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("NVARCHAR2(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("\"NormalizedUserName\" IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Marka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("MarkaAdı")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("Markas");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.MyPhone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("PhoneName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("MyPhones");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AlternatifUrun")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("AppUserID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderAdress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderApartman")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderDaire")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderFirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderIlce")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderKat")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderMail")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderPhone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderSehir")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderSurname")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("OrderUserPhone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("TeslimatSaati")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TeslimatYontemi")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.HasIndex("AppUserID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.OrderDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<double>("Count")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("OrderID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProductID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("ALTGRUP1")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ALTGRUP2")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ALTGRUP3")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ANAGRUP")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("AnaBarcode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double?>("DiscountedPrice")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("MarkaID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<double>("Price")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("ProductType")
                        .HasColumnType("NUMBER(10)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<int>("Stock")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.HasIndex("MarkaID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Slider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.SocialMedia", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("MediaName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("MediaUrl")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("ID");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.UserAdres", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AppUserID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<bool>("Selected")
                        .HasColumnType("NUMBER(1)");

                    b.Property<bool>("Status")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("UserAdress")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserApartman")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserDaire")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserIlce")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserKat")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserSehir")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ID");

                    b.HasIndex("AppUserID");

                    b.ToTable("UserAdreses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.District", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Order", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserID");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.OrderDetail", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Okyanus.EntityLayer.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Product", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.Marka", "Marka")
                        .WithMany()
                        .HasForeignKey("MarkaID");

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.UserAdres", b =>
                {
                    b.HasOne("Okyanus.EntityLayer.Entities.identitiy.AppUser", "AppUser")
                        .WithMany("UserAdreses")
                        .HasForeignKey("AppUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.identitiy.AppUser", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserAdreses");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Okyanus.EntityLayer.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
