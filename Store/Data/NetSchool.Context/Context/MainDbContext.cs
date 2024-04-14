namespace Cake_store.Context;

using Cake_store.Context.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Context.Context.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class MainDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<User> Users { get; set; }

    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOrderItems();
        modelBuilder.ConfigureImages();
        modelBuilder.ConfigureCategories();
        modelBuilder.ConfigureOrders();
        modelBuilder.ConfigureProducts();
        modelBuilder.ConfigureReviews();
        modelBuilder.ConfigureUsers();
    }
}
