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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name = "Breda", Address = "Konijnenberg 24" },
                new Location { Id = 2, Name = "Amsterdam", Address = "Nachtwachtlaan 20" },
                new Location { Id = 3, Name = "Utrecht", Address = "Vliegend Hertlaan 39" },
                new Location { Id = 4, Name = "Arnhem", Address = "Velperweg 27" },
                new Location { Id = 5, Name = "Enschede", Address = "Brouwerijstraat 1" },
                new Location { Id = 6, Name = "Maastricht", Address = "Vrijthof 23" }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "Volkswagen", Model = "ID.3", Image = "https://dam.broekhuis.online/online/broekhuis/modelpaginas/volkswagen/image-thumb__29831__original/hero-vw-id3-mob.webp", Available=true, LocationId = 1 },
                new Car { Id = 2, Brand = "Volkswagen", Model = "ID.3", Image = "https://dam.broekhuis.online/online/broekhuis/modelpaginas/volkswagen/image-thumb__29831__original/hero-vw-id3-mob.webp", Available = true, LocationId = 1 },
                new Car { Id = 3, Brand = "Volkswagen", Model = "ID.3", Image = "https://dam.broekhuis.online/online/broekhuis/modelpaginas/volkswagen/image-thumb__29831__original/hero-vw-id3-mob.webp", Available = true, LocationId = 1 },
                new Car { Id = 4, Brand = "Volkswagen", Model = "ID.3", Image = "https://dam.broekhuis.online/online/broekhuis/modelpaginas/volkswagen/image-thumb__29831__original/hero-vw-id3-mob.webp", Available = true, LocationId = 1 },
                new Car { Id = 5, Brand = "Audi", Model = "E-tron", Image = "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpg", Available = true, LocationId = 1 },
                new Car { Id = 6, Brand = "Audi", Model = "E-tron", Image = "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpgp", Available = true, LocationId = 1 },
                new Car { Id = 7, Brand = "Audi", Model = "E-tron", Image = "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpg", Available = true, LocationId = 1 },
                new Car { Id = 8, Brand = "Audi", Model = "E-tron", Image = "https://ev-database.org/img/auto/Audi_e-tron/Audi_e-tron-01@2x.jpg", Available = true, LocationId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }

}
