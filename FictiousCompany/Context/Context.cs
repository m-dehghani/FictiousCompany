﻿using FictiousCompany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FictiousCompany.Context
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(DbContextOptions options, IConfiguration configration)
            : base(options) => _configuration = configration;

        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("default"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            const string priceDecimalType = "decimal(20,2)";


        }
    }
}
