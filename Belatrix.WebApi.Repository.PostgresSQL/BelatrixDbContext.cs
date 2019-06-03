using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.PostgresSQL.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Belatrix.WebApi.Repository
{
    public class BelatrixDbContext : DbContext
    {
        public BelatrixDbContext(DbContextOptions<BelatrixDbContext> opt) : base(opt)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
        }
    }
}
