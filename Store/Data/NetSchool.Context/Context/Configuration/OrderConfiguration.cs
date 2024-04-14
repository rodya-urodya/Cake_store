using Cake_store.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context
{
    public static class OrderConfiguration
    {
        public static void ConfigureOrders(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Status).HasMaxLength(100);
            modelBuilder.Entity<Order>().HasMany(x => x.OrderItems).WithOne(x => x.Order);
            modelBuilder.Entity<Product>().HasOne(x => x.User).WithMany(x => x.Products);
        }
    }
}
