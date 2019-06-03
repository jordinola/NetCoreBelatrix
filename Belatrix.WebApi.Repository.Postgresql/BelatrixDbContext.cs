using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql.Configurations;
using Belatrix.WebApi.Repository.PostgresSQL.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class BelatrixDbContext : DbContext
    {
        public BelatrixDbContext(DbContextOptions<BelatrixDbContext> opt)
            :base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(new CustomerConfig());
            modelBuilder.ApplyConfiguration<Order>(new OrderConfig());
            modelBuilder.ApplyConfiguration<OrderItem>(new OrderItemConfig());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfig());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfig());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
