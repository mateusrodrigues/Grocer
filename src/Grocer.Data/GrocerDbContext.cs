using Grocer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Grocer.Data
{
    public class GrocerDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase();
        }
    }
}
