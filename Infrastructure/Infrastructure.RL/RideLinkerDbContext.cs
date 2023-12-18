using Microsoft.EntityFrameworkCore;
using Core.Domain;

namespace Infrastructure.RL
{
    public class RideLinkerDbContext : DbContext
    {
        public RideLinkerDbContext(DbContextOptions<RideLinkerDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
