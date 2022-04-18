using Microsoft.EntityFrameworkCore;

namespace M10Assignment.Admin.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        { }
        public DbSet<Airport> Airports { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airport>().HasData(
                new Airport
                {
                    AirportID = 1,
                    Code = "GSP",
                    Name = "Greenville-Spartanburg-Anderson"
                },
                new Airport
                {
                    AirportID = 2,
                    Code = "GMU",
                    Name = "Greenville Downtown Airport"
                },
                new Airport
                {
                    AirportID = 3,
                    Code = "GYH",
                    Name = "Donaldson Field Airport"
                },
                new Airport
                {
                    AirportID = 4,
                    Code = "SPA",
                    Name = "Spartanburg Downtown Airport"
                });
        }
    }

}
