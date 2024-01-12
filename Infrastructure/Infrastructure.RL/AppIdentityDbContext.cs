﻿using Core.Domain;
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
                Id = "1",
                Name = "ADMIN",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id ="2",
                Name = "USER",
                NormalizedName = "USER"
            }
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "1",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "Admin1234!"),
                SecurityStamp = string.Empty,
            }
        );
    }
}