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
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseIdentityColumns();

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, ERole = ERoles.USER });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 2, ERole = ERoles.INSTRUCTOR });
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 3, ERole = ERoles.ADMIN });

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "ekrem", Password = "123", Role = ERoles.ADMIN, Name = "eko", Surname = "ozgur", MobilePhone = "5076275287" });
            modelBuilder.Entity<Basket>().HasData(
                new Basket { UserId = 1, ProductCount = 0, Price = 0 });
            

            modelBuilder.Entity<BasketProduct>().HasKey(bp => new { bp.BasketId, bp.ProductId });
            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Basket)
                .WithMany(p => p.BasketProducts)
                .HasForeignKey(bp => bp.BasketId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Product>().HasData(new Product { ProductId = 1 , UserId = 1, Price = 10, DiscountPercent = 10,
                             Name = "DenemeUrun", CourseHourDuration = "5", CourseMinuteDuration = "10", Explanation = "AAA", DiscountPrice = 9});
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                UserId = 1,
                Price = 10,
                DiscountPercent = 10,
                Name = "DenemeUrun",
                CourseHourDuration = "5",
                CourseMinuteDuration = "10",
                Explanation = "AAA",
                DiscountPrice = 9
            });


            modelBuilder.Entity<BasketProduct>().HasData(new BasketProduct { ProductId = 1, BasketId = 1, ProductQuantity = 5 });
            modelBuilder.Entity<BasketProduct>().HasData(new BasketProduct { ProductId = 2, BasketId = 1, ProductQuantity = 1 });

        }
    }
}
