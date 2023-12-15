using Microsoft.EntityFrameworkCore;
using Models;

namespace RideLinkerAPI.Data
{
    public class RideLinkerDbContext : DbContext
    {
        public RideLinkerDbContext(DbContextOptions<RideLinkerDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
