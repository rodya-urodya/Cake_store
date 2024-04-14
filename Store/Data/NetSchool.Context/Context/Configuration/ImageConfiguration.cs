using Cake_store.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake_store.Context
{
    public static class ImageConfiguration
    {
        public static void ConfigureImages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().ToTable("images");
            modelBuilder.Entity<Image>().HasOne(x => x.Product).WithMany(x => x.Images);
        }
    }
}
