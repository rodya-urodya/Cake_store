using Cake_store.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context
{
    public static class OrderItemConfiguration
    {
        public static void ConfigureOrderItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>().ToTable("orderitems");
            modelBuilder.Entity<OrderItem>().Property(x => x.Quantity).HasMaxLength(30);
            modelBuilder.Entity<OrderItem>().Property(x => x.Price).HasMaxLength(100);
            modelBuilder.Entity<OrderItem>().HasOne(x => x.Product);
            modelBuilder.Entity<OrderItem>().HasOne(x => x.Order).WithMany(x => x.OrderItems);
        }
    }
}
