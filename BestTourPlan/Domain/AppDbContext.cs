using BestTourPlan.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestTourPlan.Domain
{
    public class CustomIdentityUser : IdentityUser
    {
        public string ImageSource { get; set; }
    }

    public class AppDbContext : IdentityDbContext<CustomIdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
            {
                Id = "edac7def-db14-4655-9504-1e028950cbb1", //https://www.guidgenerator.com/online-guid-generator.aspx
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<CustomIdentityUser>()
                .HasData(new CustomIdentityUser
            {
                Id = "96d2dddf-f662-4362-b1c3-5992e20fc4be",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "malmugespa@nedoz.com",
                NormalizedEmail = "MALMUGESPA@NEDOZ.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "edac7def-db14-4655-9504-1e028950cbb1",
                    UserId = "96d2dddf-f662-4362-b1c3-5992e20fc4be"
                });

            builder.Entity<Hotel>()
                .HasData(new Hotel
                {
                    Id = new Guid("dcd862fd-14e6-499e-a41a-34ca091fab72"),
                    Name = "Hotel Transylvania",
                    Description = "Half-Board/ All Inclusive + Complimentary Activities + Bonus For Monsters",
                    Rating = 4.0,
                    ImagePath = "~/img/castle.jpg",
                    Price = 9500.0m
                },
                new Hotel
                {
                    Id = new Guid("be0cc7f6-be5b-4886-af6c-0ff8876f96d8"),
                    Name = "Grand Hilton Hotel",
                    Description = "Half-Board/ All Inclusive + Complimentary Activities + Child Stays Free",
                    Rating = 5.0,
                    ImagePath = "~/img/slide-1.jpg",
                    Price = 8500.0m
                },
                new Hotel
                {
                    Id = new Guid("0841e324-986f-4fdf-9fb7-23f435e500d3"),
                    Name = "Park Inn by Radisson Pulkovskaya",
                    Description = "Great option for 2 persons/ Shuttle service from/to the airport",
                    Rating = 4.0,
                    ImagePath = "~/img/park-inn.jpg",
                    Price = 6500.0m
                });
        }
    }
}
