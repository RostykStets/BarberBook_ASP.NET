using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //           .SetBasePath(Directory.GetCurrentDirectory())
        //           .AddJsonFile("appsettings.json")
        //           .Build();
        //        var connectionString = configuration.GetConnectionString("BarberBook_Connection");
        //        optionsBuilder.UseNpgsql(connectionString, x => x.MigrationsAssembly("DataAccessLayer"));
        //    }
        //}

        public DbSet<BarberShop> BarberShops { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Guest> Guests { get; set; } // PK int
        public DbSet<RegistrationKey> RegistrationKeys { get; set; } // PK int
        public DbSet<History> History { get; set; } // PK int
        public DbSet<Review> Reviews { get; set; } // PK int, fk edited
        public DbSet<Schedule> Schedules { get; set; } // PK int, fk edited
        public DbSet<Service> Services { get; set; } // PK int, fk edited
        public DbSet<Visit> Visits { get; set; } // PK int, fk edited
    }
}
