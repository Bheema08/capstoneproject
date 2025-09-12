using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Vehicle_ProjectJwt.Models
{
    public class VCDbContext: DbContext
    {
        public VCDbContext() { }

        public VCDbContext(DbContextOptions<VCDbContext> options) : base(options)
        {
        }

        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}

