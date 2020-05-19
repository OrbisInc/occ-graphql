using Microsoft.EntityFrameworkCore;
using Occ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Occ.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}