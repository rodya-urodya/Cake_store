namespace Cake_store.Context;

using Microsoft.EntityFrameworkCore;
using Cake_store.Context.Entities;

public static class CategoriesContextConfiguration
{
    public static void ConfigureCategories(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().ToTable("categories");
        modelBuilder.Entity<Category>().Property(x => x.Name).HasMaxLength(100);
        modelBuilder.Entity<Category>().HasMany(x => x.Products).WithMany(x => x.Categories);
    }
}