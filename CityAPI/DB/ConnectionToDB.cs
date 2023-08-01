using CityAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CityAPI.DB
{
    public class ConnectionToDB : DbContext
    {
        public ConnectionToDB(DbContextOptions options) : base(options)
        {
        }
        public DbSet<City> cities { get; set; }
        public DbSet<City_dto> city_Dtos { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().Property(x => x.name).IsRequired();
            modelBuilder.Entity<City>().HasIndex(x => x.name).IsUnique();

            modelBuilder.Entity<City_dto>().Property(x => x.name).IsRequired();
            modelBuilder.Entity<City_dto>().HasIndex(x => x.name).IsUnique();

            modelBuilder.Entity<Vehicle>().Property(x => x.vehicle).IsRequired();
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.vehicle).IsUnique();

        }
    }
}
