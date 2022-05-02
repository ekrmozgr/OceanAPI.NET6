using Microsoft.EntityFrameworkCore;
using OceanAPI.NET6.Models;

namespace OceanAPI.NET6.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opt) : base(opt)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<CompanyContacts>  CompanyContacts { get; set; }
        public DbSet<FAQCategory> FaqCategories { get; set; }
        public DbSet<FAQ> Faq { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseIdentityColumns();

            modelBuilder.Entity<CompanyContacts>().HasData(
                new CompanyContacts { CompanyId = 1, CompanyName = "Ocean", Address = "Deneme Adres", Email = "deneme@outlook.com", PhoneNo = "5076275287" });

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, ERole = ERoles.USER });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 2, ERole = ERoles.INSTRUCTOR });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 3, ERole = ERoles.ADMIN });

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "ekrem@outlook", Password = "ekrem123.", Role = ERoles.ADMIN, Name = "eko", Surname = "ozgur", MobilePhone = "5076275287" });
            modelBuilder.Entity<Basket>().HasData(
                new Basket { UserId = 1, ProductCount = 0, Price = 0 });


            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 1, FaqCategory = EFAQCategory.ABOUT_OUR_ONLINE_COURSES });
            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 2, FaqCategory = EFAQCategory.ENROLMENT_PROCESS });
            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 3, FaqCategory = EFAQCategory.ACCOUNT_ACCESS });
            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 4, FaqCategory = EFAQCategory.PAYMENT });
            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 5, FaqCategory = EFAQCategory.COMMUNITY_SUPPORT });
            modelBuilder.Entity<FAQCategory>().HasData(
                new FAQCategory { FAQCategoryId = 6, FaqCategory = EFAQCategory.OTHER });

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.ABOUT_OUR_ONLINE_COURSES, FAQCategoryId = (int)EFAQCategory.ABOUT_OUR_ONLINE_COURSES, FAQId = 1, Question = "Deneme", Answer = "Deneme" });
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.ENROLMENT_PROCESS, FAQCategoryId = (int)EFAQCategory.ENROLMENT_PROCESS, FAQId = 2, Question = "Deneme", Answer = "Deneme" });
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.ACCOUNT_ACCESS, FAQCategoryId = (int)EFAQCategory.ACCOUNT_ACCESS, FAQId = 3, Question = "Deneme", Answer = "Deneme" });
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.PAYMENT, FAQId = 4, FAQCategoryId = (int)EFAQCategory.PAYMENT, Question = "Deneme", Answer = "Deneme" });
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.COMMUNITY_SUPPORT, FAQId = 5, FAQCategoryId = (int)EFAQCategory.COMMUNITY_SUPPORT, Question = "Deneme", Answer = "Deneme" });
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { FaqCategory = EFAQCategory.OTHER, FAQId = 6, FAQCategoryId = (int)EFAQCategory.OTHER, Question = "Deneme", Answer = "Deneme" });

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 1, ProductCategorys = EProductCategory.BULUT });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 2, ProductCategorys = EProductCategory.DEVOPS });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 3, ProductCategorys = EProductCategory.ERP });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 4, ProductCategorys = EProductCategory.OYUN_TASARIMI_GELISTIRME });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 5, ProductCategorys = EProductCategory.AG_TEKNOLOJILERI });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 6, ProductCategorys = EProductCategory.SIBER_GUVENLIK });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 7, ProductCategorys = EProductCategory.UI_UX_TASARIMI });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 8, ProductCategorys = EProductCategory.VERI_BILIMI });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 9, ProductCategorys = EProductCategory.BACK_END_DEVELOPER });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 10, ProductCategorys = EProductCategory.FRONT_END_DEVELOPER });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 11, ProductCategorys = EProductCategory.FULL_STACK_DEVELOPER });
            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductCategoryId = 12, ProductCategorys = EProductCategory.GAME_DEVELOPER });
            modelBuilder.Entity<ProductCategory>().HasData(
               new ProductCategory { ProductCategoryId = 13, ProductCategorys = EProductCategory.MOBILE_DEVELOPER });



            modelBuilder.Entity<BasketProduct>().HasKey(bp => new { bp.BasketId, bp.ProductId });
            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Basket)
                .WithMany(p => p.BasketProducts)
                .HasForeignKey(bp => bp.BasketId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
