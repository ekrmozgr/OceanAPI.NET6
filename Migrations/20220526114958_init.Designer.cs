﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanAPI.NET6.Data;

#nullable disable

namespace OceanAPI.NET6.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220526114958_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OceanAPI.NET6.Models.Basket", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Baskets");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Price = 0m,
                            ProductCount = 0
                        },
                        new
                        {
                            UserId = 2,
                            Price = 0m,
                            ProductCount = 0
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.BasketProduct", b =>
                {
                    b.Property<int>("BasketId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("BasketId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfComment")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.CompanyContacts", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("CompanyContacts");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Address = "Deneme Adres",
                            CompanyName = "Ocean",
                            Email = "deneme@outlook.com",
                            PhoneNo = "5076275287"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"), 1L, 1);

                    b.Property<string>("CouponCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CouponId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.CourseLevel", b =>
                {
                    b.Property<int>("CourseLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseLevelId"), 1L, 1);

                    b.Property<string>("ECourseLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CourseLevelId");

                    b.ToTable("CourseLevels");

                    b.HasData(
                        new
                        {
                            CourseLevelId = 1,
                            ECourseLevel = "BASLANGIC"
                        },
                        new
                        {
                            CourseLevelId = 2,
                            ECourseLevel = "ORTA"
                        },
                        new
                        {
                            CourseLevelId = 3,
                            ECourseLevel = "ILERI"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FAQ", b =>
                {
                    b.Property<int>("FAQId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQId"), 1L, 1);

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FAQCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("FaqCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FAQId");

                    b.HasIndex("FAQCategoryId");

                    b.ToTable("Faq");

                    b.HasData(
                        new
                        {
                            FAQId = 1,
                            Answer = "Deneme",
                            FAQCategoryId = 1,
                            FaqCategory = "ABOUT_OUR_ONLINE_COURSES",
                            Question = "Deneme"
                        },
                        new
                        {
                            FAQId = 2,
                            Answer = "Deneme",
                            FAQCategoryId = 2,
                            FaqCategory = "ENROLMENT_PROCESS",
                            Question = "Deneme"
                        },
                        new
                        {
                            FAQId = 3,
                            Answer = "Deneme",
                            FAQCategoryId = 3,
                            FaqCategory = "ACCOUNT_ACCESS",
                            Question = "Deneme"
                        },
                        new
                        {
                            FAQId = 4,
                            Answer = "Deneme",
                            FAQCategoryId = 4,
                            FaqCategory = "PAYMENT",
                            Question = "Deneme"
                        },
                        new
                        {
                            FAQId = 5,
                            Answer = "Deneme",
                            FAQCategoryId = 5,
                            FaqCategory = "COMMUNITY_SUPPORT",
                            Question = "Deneme"
                        },
                        new
                        {
                            FAQId = 6,
                            Answer = "Deneme",
                            FAQCategoryId = 6,
                            FaqCategory = "OTHER",
                            Question = "Deneme"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FAQCategory", b =>
                {
                    b.Property<int>("FAQCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FAQCategoryId"), 1L, 1);

                    b.Property<string>("FaqCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("FAQCategoryId");

                    b.ToTable("FaqCategories");

                    b.HasData(
                        new
                        {
                            FAQCategoryId = 1,
                            FaqCategory = "ABOUT_OUR_ONLINE_COURSES"
                        },
                        new
                        {
                            FAQCategoryId = 2,
                            FaqCategory = "ENROLMENT_PROCESS"
                        },
                        new
                        {
                            FAQCategoryId = 3,
                            FaqCategory = "ACCOUNT_ACCESS"
                        },
                        new
                        {
                            FAQCategoryId = 4,
                            FaqCategory = "PAYMENT"
                        },
                        new
                        {
                            FAQCategoryId = 5,
                            FaqCategory = "COMMUNITY_SUPPORT"
                        },
                        new
                        {
                            FAQCategoryId = 6,
                            FaqCategory = "OTHER"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Favourites", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductCount")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Favorites");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            ProductCount = 0
                        },
                        new
                        {
                            UserId = 2,
                            ProductCount = 0
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FavouritesProduct", b =>
                {
                    b.Property<int>("FavouritesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("FavouritesId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("FavouritesProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<DateTime>("DateOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("RecipientMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.OrderProduct", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("ProductPrice")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyWebsite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseHourDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("CourseLevelId")
                        .HasColumnType("int");

                    b.Property<string>("CourseMinuteDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DiscountPercent")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountPrice")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("ProductCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<bool>("isAvailable")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductCategoryId"), 1L, 1);

                    b.Property<string>("ProductCategorys")
                        .IsRequired()
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ProductCategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new
                        {
                            ProductCategoryId = 1,
                            ProductCategorys = "BULUT"
                        },
                        new
                        {
                            ProductCategoryId = 2,
                            ProductCategorys = "DEVOPS"
                        },
                        new
                        {
                            ProductCategoryId = 3,
                            ProductCategorys = "ERP"
                        },
                        new
                        {
                            ProductCategoryId = 4,
                            ProductCategorys = "OYUN_TASARIMI_GELISTIRME"
                        },
                        new
                        {
                            ProductCategoryId = 5,
                            ProductCategorys = "AG_TEKNOLOJILERI"
                        },
                        new
                        {
                            ProductCategoryId = 6,
                            ProductCategorys = "SIBER_GUVENLIK"
                        },
                        new
                        {
                            ProductCategoryId = 7,
                            ProductCategorys = "UI_UX_TASARIMI"
                        },
                        new
                        {
                            ProductCategoryId = 8,
                            ProductCategorys = "VERI_BILIMI"
                        },
                        new
                        {
                            ProductCategoryId = 9,
                            ProductCategorys = "BACK_END_DEVELOPER"
                        },
                        new
                        {
                            ProductCategoryId = 10,
                            ProductCategorys = "FRONT_END_DEVELOPER"
                        },
                        new
                        {
                            ProductCategoryId = 11,
                            ProductCategorys = "FULL_STACK_DEVELOPER"
                        },
                        new
                        {
                            ProductCategoryId = 12,
                            ProductCategorys = "GAME_DEVELOPER"
                        },
                        new
                        {
                            ProductCategoryId = 13,
                            ProductCategorys = "MOBILE_DEVELOPER"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"), 1L, 1);

                    b.Property<string>("ERole")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            ERole = "USER"
                        },
                        new
                        {
                            RoleId = 2,
                            ERole = "INSTRUCTOR"
                        },
                        new
                        {
                            RoleId = 3,
                            ERole = "ADMIN"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("MobilePhone")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "ekrem.ozgurr@outlook.com",
                            MobilePhone = "5076275287",
                            Name = "Ekrem",
                            Password = "Ekrem123.",
                            Role = "ADMIN",
                            Surname = "Ozgur"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "hacer@outlook",
                            MobilePhone = "5550268550",
                            Name = "Hacer",
                            Password = "Hacer123.",
                            Role = "ADMIN",
                            Surname = "Durak"
                        });
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Basket", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithOne("Basket")
                        .HasForeignKey("OceanAPI.NET6.Models.Basket", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.BasketProduct", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.Basket", "Basket")
                        .WithMany("BasketProducts")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.Product", "Product")
                        .WithMany("BasketProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Comments", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Coupon", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.Order", "Order")
                        .WithMany("Coupons")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithMany("Coupons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FAQ", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.FAQCategory", null)
                        .WithMany("faqs")
                        .HasForeignKey("FAQCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Favourites", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithOne("Favourites")
                        .HasForeignKey("OceanAPI.NET6.Models.Favourites", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FavouritesProduct", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.Favourites", "Favourites")
                        .WithMany("FavouritesProducts")
                        .HasForeignKey("FavouritesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.Product", "Product")
                        .WithMany("FavouritesProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Favourites");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Order", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.OrderProduct", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanAPI.NET6.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Product", b =>
                {
                    b.HasOne("OceanAPI.NET6.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Basket", b =>
                {
                    b.Navigation("BasketProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.FAQCategory", b =>
                {
                    b.Navigation("faqs");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Favourites", b =>
                {
                    b.Navigation("FavouritesProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Order", b =>
                {
                    b.Navigation("Coupons");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.Product", b =>
                {
                    b.Navigation("BasketProducts");

                    b.Navigation("Comments");

                    b.Navigation("FavouritesProducts");

                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("OceanAPI.NET6.Models.User", b =>
                {
                    b.Navigation("Basket")
                        .IsRequired();

                    b.Navigation("Comments");

                    b.Navigation("Coupons");

                    b.Navigation("Favourites")
                        .IsRequired();

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
