using Microsoft.EntityFrameworkCore;

namespace RoomCrudTestDemo.Models
{
    public class RFCoreDbContext:DbContext
    {
        //Constructor calling the Base DbContext Class Constructor
        public RFCoreDbContext(DbContextOptions<RFCoreDbContext> options) : base(options)
        {
        }
        //OnConfiguring() method is used to select and configure the data source
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DATTA;Database=roomates;Trusted_Connection=True;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().ToTable("room");
        }

        public DbSet<Room> roomates { get; set; }
    }
}
