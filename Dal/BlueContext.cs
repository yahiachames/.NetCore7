using Dal.Model;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class BlueContext : DbContext
    {
        public DbSet<Travel> Travels { get; set; }




        public BlueContext(DbContextOptions<BlueContext> options) : base(options)
        {
        }

        protected BlueContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase("BlueInMemoryDb");
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Travel>()
  .Property(t => t.TravelID)
 .ValueGeneratedOnAdd();
            modelBuilder.Entity<Travel>().HasData(
            new Travel()
            {
                TravelID = 1,
                Departure = "Lyon",
                DepartureDate = new DateTime(2023, 02, 12, 14, 20, 00),
                Arrival = "Paris",
                ArrivalDate = new DateTime(2023, 02, 12, 16, 30, 00),
                NumberOfPassengers = 2
            },
            new Travel()
            {
                TravelID = 2,
                Departure = "Paris",
                DepartureDate = new DateTime(2023, 02, 14, 08, 13, 00),
                Arrival = "London",
                ArrivalDate = new DateTime(2023, 02, 14, 13, 10, 00),
                NumberOfPassengers = 1
            }
            );
            base.OnModelCreating(modelBuilder);

        }
    }
}
