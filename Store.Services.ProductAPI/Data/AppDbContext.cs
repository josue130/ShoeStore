using Microsoft.EntityFrameworkCore;
using Store.Services.ProductAPI.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Store.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "NikeCourt Air Zoom Vapor 11",
                Price = 170,
                Description = "Hard Court Tennis Shoes",
                ImageUrl = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/733b75de-1ebc-4842-baad-2035b1d5e4e2/M+NIKE+ZOOM+VAPOR+11+HC.png",
                CategoryName = "Tennis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Nike Zoom GP Challenge 1",
                Price = 160,
                Description = "Hard Court Tennis Shoes",
                ImageUrl = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/533dfb67-8c51-4ace-ac1e-ba51f1ac7766/W+ZOOM+GP+CHALLENGE+1+HC.png",
                CategoryName = "Tennis"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "Nike Zoom Challenge",
                Price = 120,
                Description = "Pickleball shoes",
                ImageUrl = "https://static.nike.com/a/images/c_limit,w_592,f_auto/t_product_v1/e1e4ff2e-7111-419d-8165-7874d8e4846b/M+ZOOM+CHALLENGE+PB.png",
                CategoryName = "Tennis"
            });
          

        }
    }
}
