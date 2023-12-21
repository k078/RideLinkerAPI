using Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.RL;
public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                UserName = "Admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "Admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Admin1234!"),
                SecurityStamp = string.Empty
            }
        );
    }
}