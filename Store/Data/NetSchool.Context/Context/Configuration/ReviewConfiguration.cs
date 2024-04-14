using Cake_store.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context
{
    public static class ReviewConfiguration
    {
        public static void ConfigureReviews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Review>().Property(x => x.Content).HasMaxLength(1000);
            modelBuilder.Entity<Review>().HasOne(x => x.Product).WithMany(x => x.Reviews);
            modelBuilder.Entity<Review>().HasIndex(r => new { r.UserId, r.ProductId }).IsUnique();
        }
    }
}
