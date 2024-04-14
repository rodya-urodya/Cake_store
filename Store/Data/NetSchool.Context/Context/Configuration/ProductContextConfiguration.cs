using Cake_store.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cake_store.Context
{
    public static class ProductContextConfiguration
    {
        public static void ConfigureProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasMaxLength(30);
            modelBuilder.Entity<Product>().Property(x => x.Price).HasMaxLength(100);
            modelBuilder.Entity<Product>().HasMany(x => x.Images).WithOne(x => x.Product);
            modelBuilder.Entity<Product>().HasMany(x => x.Reviews).WithOne(x => x.Product);
            modelBuilder.Entity<Product>().HasOne(x => x.User).WithMany(x => x.Products);
        }
    }
}
