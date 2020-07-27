using FictiousCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        
        public Context(DbContextOptions<Context> options, IConfiguration configration)
           : base(options)
        {
            _configuration = configration;
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Sell> Sells { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("default"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            const string priceDecimalType = "decimal(20,2)";

            builder.Entity<Product>().Property(p => p.Price).HasColumnType(priceDecimalType);
            builder.Entity<Product>().HasKey(p => p.Code);


            builder.Entity<CategoryProduct>().HasKey(p => new { p.ProductCode, p.CategoryId });
            builder.Entity<SellProducts>().HasKey(p => new { p.ProductCode, p.SellId });




        }
    }
}
