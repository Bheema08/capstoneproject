using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Diagnostics;

namespace CanteenProject.Models
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext() { }
        public MasterDbContext(DbContextOptions<MasterDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            //modelBuilder.Entity<Trans>().ToTable("Trans");
            //modelBuilder.Entity<Login>().ToTable("Login");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
